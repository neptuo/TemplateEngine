﻿using Neptuo.TemplateEngine.Navigation;
using Neptuo.TemplateEngine.Templates;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Controllers;
using Neptuo.TemplateEngine.Providers.ModelBinders;
using Neptuo.Templates;
using Neptuo.Templates.Compilation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;
using Neptuo.TemplateEngine.Providers;
using Neptuo.TemplateEngine.Security;

namespace Neptuo.TemplateEngine.Hosting
{
    public abstract class TemplateHttpHandlerBase : IHttpHandler, IRequiresSessionState
    {
        public const string EngineRequestType = "X-EngineRequestType";
        public const string EngineRequestTypePartial = "Partial";

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext httpContext)
        {
            Guard.NotNull(httpContext, "context");
            
            IDependencyContainer dependencyContainer = GetDependencyContainer().CreateChildContainer();
            
            //TODO: Check whether can read
            FormUri formUri = GetCurrentFormUri(httpContext);
            IUserContext userContext = dependencyContainer.Resolve<IUserContext>();
            if (formUri == null || userContext.Permissions.IsAllowed(formUri.Identifier(), "ReadWrite"))
            {



                GlobalNavigationCollection globalNavigations = dependencyContainer.Resolve<GlobalNavigationCollection>();

                string navigation = ExecuteControllers(httpContext, dependencyContainer);


                if (httpContext.Request.Headers[EngineRequestType] == EngineRequestTypePartial)
                {
                    // Partial ajax request - serialize messages and navigations
                    MessageStorage messageStorage = dependencyContainer.Resolve<MessageStorage>();

                    string redirectUrl = null;
                    FormUri to;
                    if (globalNavigations.TryGetValue(navigation, out to))
                        redirectUrl = to.Url();

                    //JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                    //string response = javaScriptSerializer.Serialize(new PartialResponse(messageStorage, redirectUrl));

                    string response = JsonConvert.SerializeObject(new ServerPartialResponse(messageStorage.GetStorage(), redirectUrl));
                    httpContext.Response.ContentType = "application/json";
                    httpContext.Response.Write(response);
                }
                else
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    // Standart request - process redirects and eventually rerender current view
                    INavigator navigator = dependencyContainer.Resolve<INavigator>();
                    if (!ProcessNavigationRule(navigation, globalNavigations, navigator))
                    {
                        BaseGeneratedView view = GetCurrentView(httpContext);
                        IComponentManager componentManager = GetComponentManager(httpContext);

                        dependencyContainer.RegisterInstance<IComponentManager>(componentManager);

                        view.Setup(new BaseViewPage(componentManager), componentManager, dependencyContainer);
                        Debug.WriteLine("Template after setup: {0}ms", stopwatch.ElapsedMilliseconds);

                        view.CreateControls();
                        Debug.WriteLine("Template after create controls: {0}ms", stopwatch.ElapsedMilliseconds);

                        view.Init();
                        Debug.WriteLine("Template after init: {0}ms", stopwatch.ElapsedMilliseconds);

                        view.Render(new ExtendedHtmlTextWriter(httpContext.Response.Output));
                        Debug.WriteLine("Template after render: {0}ms", stopwatch.ElapsedMilliseconds);

                        view.Dispose();
                    }

                    stopwatch.Stop();
                    Debug.WriteLine("Template total: {0}ms", stopwatch.ElapsedMilliseconds);
                }

            }
            else
            {
                httpContext.Response.StatusCode = 403;
                httpContext.Response.End();
            }
        }

        protected virtual string ExecuteControllers(HttpContext httpContext, IDependencyContainer dependencyContainer)
        {
            IControllerRegistry registry = dependencyContainer.Resolve<IControllerRegistry>();
            IModelBinder modelBinder = dependencyContainer.Resolve<IModelBinder>();
            MessageStorage messageStorage = dependencyContainer.Resolve<MessageStorage>();

            string navigation = null;
            foreach (string key in httpContext.Request.Form.AllKeys)
            {
                IController controller;
                if (registry.TryGet(key, out controller))
                {
                    IControllerContext context = new ControllerContext(key, modelBinder, dependencyContainer, messageStorage);
                    controller.Execute(context);
                    navigation = context.Navigation;
                }
            }

            return navigation;
        }

        protected virtual bool ProcessNavigationRule(string navigation, GlobalNavigationCollection globalNavigations, INavigator navigator)
        {
            FormUri to;
            if (globalNavigations.TryGetValue(navigation, out to))
            {
                navigator.Open(to);
                return true;
            }
            return false;
        }

        protected virtual IComponentManager GetComponentManager(HttpContext httpContext)
        {
            return new ComponentManager();
        }

        protected abstract BaseGeneratedView GetCurrentView(HttpContext context);

        protected abstract IDependencyContainer GetDependencyContainer();

        protected abstract FormUri GetCurrentFormUri(HttpContext context);
    }
}
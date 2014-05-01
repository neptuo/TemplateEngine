using Neptuo.TemplateEngine.Controllers;
using Neptuo.TemplateEngine.Providers;
using Neptuo.TemplateEngine.Providers.ModelBinders;
using Neptuo.TemplateEngine.Routing;
using SharpKit.Html;
using SharpKit.JavaScript;
using SharpKit.jQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class FormPostInvoker : IFormPostInvoker
    {
        protected IApplication Application { get; private set; }
        protected IAsyncControllerRegistry ControllerRegistry { get; private set; }
        protected FormRequestContext Context { get; private set; }

        public event Action<IFormPostInvoker> OnSuccess;
        public event Action<IFormPostInvoker, ErrorModel> OnError;

        public FormPostInvoker(IApplication application, IAsyncControllerRegistry controllerRegistry, FormRequestContext context)
        {
            Guard.NotNull(application, "application");
            Guard.NotNull(context, "context");
            Guard.NotNull(controllerRegistry, "controllerRegistry");
            Application = application;
            ControllerRegistry = controllerRegistry;
            Context = context;
        }

        public void Invoke()
        {
            //TODO: Run AsyncControllers here!
            Application.HistoryState.Replace(new HistoryItem(Context.FormUrl, Context.ToUpdate, Context));
            
            IDependencyContainer container = Application.DependencyContainer.CreateChildContainer();
            container.RegisterInstance<IParameterProvider>(Context.Parameters.ToParameterProvider());
            IModelBinder modelBinder = container.Resolve<IModelBinder>();
            MessageStorage messageStorage = container.Resolve<MessageStorage>();

            bool isControllerInvoked = false;
            foreach (KeyValuePair<string, string> parameter in Context.Parameters)
            {
                string key = parameter.Key;
                IAsyncController controller;
                if (ControllerRegistry.TryGet(key, out controller))
                {
                    isControllerInvoked = true;
                    controller.Execute(new AsyncControllerContext(key, modelBinder, container, messageStorage, OnControllerExecuted));
                }
            }

            if (!isControllerInvoked)
            {
                JsObject headers = new JsObject();
                headers["X-EngineRequestType"] = "Partial"; //TODO: Shared constant?
                jQuery.ajax(new AjaxSettings
                {
                    url = Context.FormUrl,
                    type = "POST",
                    data = Context.Parameters,
                    headers = headers,
                    success = OnSubmitSuccess,
                    error = OnSubmitError
                });
            }
        }

        private void OnControllerExecuted()
        {
            if (OnSuccess != null)
                OnSuccess(this);
        }

        private void OnSubmitSuccess(object response, JsString status, jqXHR sender)
        {
            PartialResponse partialResponse;
            if (Converts.Try<JsObject, PartialResponse>(response.As<JsObject>(), out partialResponse))
            {
                ProcessResponse(partialResponse);

                if (OnSuccess != null)
                    OnSuccess(this);
            }
            else
            {
                //TODO: Hmh, how to solve unexpected response?
                HtmlContext.alert(status);
            }
        }

        private void ProcessResponse(PartialResponse partialResponse)
        {
            string navigationUrl = ResolveNavigationUrl(partialResponse);

            RouteValueDictionary customValues = new RouteValueDictionary()
                .AddItem("ToUpdate", Context.ToUpdate)
                .AddItem("Messages", partialResponse.Messages);

            RouteParamDictionary parameters = new RouteParamDictionary();
            // Save form request only if there wasn't redirect
            if (navigationUrl == Application.GetCurrentUrl())
                parameters = Context.Parameters.ToRouteParams();
            else
                Application.HistoryState.Push(new HistoryItem(navigationUrl, Context.ToUpdate));

            Application.Router.RouteTo(new RequestContext(navigationUrl, parameters, customValues));
        }

        private string ResolveNavigationUrl(PartialResponse partialResponse)
        {
            if (partialResponse.Navigation != null)
                return Application.ResolveUrl(partialResponse.Navigation);
            else
                return Application.GetCurrentUrl();
        }

        private void OnSubmitError(jqXHR response, JsString status, JsError error)
        {
            if (OnError != null)
                OnError(this, new ErrorModel(response.status, response.statusText, response.responseText));
        }
    }
}

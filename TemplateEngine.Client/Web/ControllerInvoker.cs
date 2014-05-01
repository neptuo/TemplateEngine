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
    public class ControllerInvoker : IControllerInvoker
    {
        protected IApplication Application { get; private set; }
        protected IAsyncControllerRegistry ControllerRegistry { get; private set; }
        protected FormRequestContext Context { get; private set; }

        public event Action<IControllerInvoker> OnSuccess;
        public event Action<IControllerInvoker, ErrorModel> OnError;

        private IAsyncControllerContext controllerContext;

        public ControllerInvoker(IApplication application, IAsyncControllerRegistry controllerRegistry, FormRequestContext context)
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
            Application.HistoryState.Replace(new HistoryItem(Context.FormUrl, Context.ToUpdate, Context));
            if (!TryInvokeControllers())
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

        private bool TryInvokeControllers()
        {
            IParameterProvider parameterProvider = Context.Parameters.ToParameterProvider();
            IDependencyContainer container = Application.DependencyContainer.CreateChildContainer();
            container.RegisterInstance<IParameterProvider>(parameterProvider);
            IModelBinder modelBinder = container.Resolve<IModelBinder>();
            MessageStorage messageStorage = container.Resolve<MessageStorage>();

            foreach (string key in parameterProvider.Keys)
            {
                IAsyncController controller;
                if (ControllerRegistry.TryGet(key, out controller))
                {
                    controllerContext = new AsyncControllerContext(key, parameterProvider, modelBinder, container, messageStorage, OnControllerExecuted);
                    controller.Execute(controllerContext);
                    return true;
                }
            }

            return false;
        }

        private void OnControllerExecuted()
        {
            ProcessResponse(new PartialResponse(controllerContext.Messages, controllerContext.Navigation));
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
            string navigationUrl = ResolveNavigationUrl(partialResponse.Navigation);

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

        private string ResolveNavigationUrl(string navigation)
        {
            if (navigation != null)
                return Application.ResolveUrl(navigation);
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

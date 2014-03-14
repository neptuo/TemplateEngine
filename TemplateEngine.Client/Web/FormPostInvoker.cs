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
        protected IDependencyContainer DependencyContainer { get; private set; }
        protected FormRequestContext Context { get; private set; }

        public event Action<IFormPostInvoker> OnSuccess;

        public FormPostInvoker(IApplication application, IDependencyContainer dependencyContainer, FormRequestContext context)
        {
            Guard.NotNull(application, "application");
            Guard.NotNull(dependencyContainer, "dependencyContainer");
            Guard.NotNull(context, "context");
            Application = application;
            DependencyContainer = dependencyContainer;
            Context = context;
        }

        public void Invoke()
        {
            Application.HistoryState.Replace(new HistoryItem(Context.FormUrl, Context.ToUpdate, Context));

            JsObject headers = new JsObject();
            headers["X-EngineRequestType"] = "Partial";
            jQuery.ajax(new AjaxSettings
            {
                url = Context.FormUrl,
                type = "POST",
                data = Context.Parameters,
                headers = headers,
                success = OnSubmitSuccess
            });
        }

        private void OnSubmitSuccess(object response, JsString status, jqXHR sender)
        {
            PartialResponse partialResponse;
            if (Converts.Try<JsObject, PartialResponse>(response.As<JsObject>(), out partialResponse))
            {
                string navigationUrl = null;
                if (partialResponse.Navigation != null)
                    navigationUrl = Application.ResolveUrl(partialResponse.Navigation);
                else
                    navigationUrl = HtmlContext.location.pathname;

                IDependencyContainer childContainer = DependencyContainer.CreateChildContainer();

                // Save form request only if there wasn't redirect
                if (navigationUrl == Application.GetCurrentUrl())
                {
                    Application.Router.RouteTo(
                        new RequestContext(
                            navigationUrl,
                            Context.Parameters.ToRouteParams(),
                            new RouteValueDictionary()
                                .AddItem("ToUpdate", Context.ToUpdate)
                                .AddItem("Messages", partialResponse.Messages)
                        )
                    );
                    InitScript.FormRequestContext = Context;
                }
                else
                {
                    Application.HistoryState.Push(new HistoryItem(navigationUrl, Context.ToUpdate));
                    Application.Router.RouteTo(
                        new RequestContext(
                            navigationUrl, 
                            new RouteParamDictionary(),
                            new RouteValueDictionary()
                                .AddItem("ToUpdate", Context.ToUpdate)
                                .AddItem("Messages", partialResponse.Messages)
                        )
                    );
                }

                if (OnSuccess != null)
                    OnSuccess(this);

                InitScript.FormRequestContext = null;
            }
            else
            {
                HtmlContext.alert(status);
            }
        }
    }
}

using Neptuo.TemplateEngine.Controllers;
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
        protected FormRequestContext Context { get; private set; }

        public event Action<IFormPostInvoker> OnSuccess;
        public event Action<IFormPostInvoker, ErrorModel> OnError;

        public FormPostInvoker(IApplication application, FormRequestContext context)
        {
            Guard.NotNull(application, "application");
            Guard.NotNull(context, "context");
            Application = application;
            Context = context;
        }

        public void Invoke()
        {
            Application.HistoryState.Replace(new HistoryItem(Context.FormUrl, Context.ToUpdate, Context));

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

        private void OnSubmitSuccess(object response, JsString status, jqXHR sender)
        {
            PartialResponse partialResponse;
            if (Converts.Try<JsObject, PartialResponse>(response.As<JsObject>(), out partialResponse))
            {
                string navigationUrl = null;
                if (partialResponse.Navigation != null)
                    navigationUrl = Application.ResolveUrl(partialResponse.Navigation);
                else
                    navigationUrl = Application.GetCurrentUrl();

                RouteValueDictionary customValues = new RouteValueDictionary()
                    .AddItem("ToUpdate", Context.ToUpdate)
                    .AddItem("Messages", partialResponse.Messages);

                // Save form request only if there wasn't redirect
                if (navigationUrl == Application.GetCurrentUrl())
                {
                    Application.Router.RouteTo(
                        new RequestContext(
                            navigationUrl,
                            Context.Parameters.ToRouteParams(),
                            customValues
                        )
                    );
                }
                else
                {
                    Application.HistoryState.Push(new HistoryItem(navigationUrl, Context.ToUpdate));
                    Application.Router.RouteTo(
                        new RequestContext(
                            navigationUrl, 
                            new RouteParamDictionary(),
                            customValues
                        )
                    );
                }

                if (OnSuccess != null)
                    OnSuccess(this);
            }
            else
            {
                //TODO: Hmh, how to solve unexpected response?
                HtmlContext.alert(status);
            }
        }

        private void OnSubmitError(jqXHR response, JsString status, JsError error)
        {
            if (OnError != null)
                OnError(this, new ErrorModel(response.status, response.statusText, response.responseText));
        }
    }
}

using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Providers.ModelBinders;
using Neptuo.Templates;
using SharpKit.JavaScript;
using SharpKit.jQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.DataSources
{
    /// <summary>
    /// Single data source proxy.
    /// Calls web data source with class name and uses <see cref="IConverter"/> to convert response JSON.
    /// </summary>
    /// <typeparam name="TResultModel">Result model type.</typeparam>
    public abstract class DataSourceProxy<TResultModel> : IClientDataSource
    {
        protected IModelBinder ModelBinder { get; private set; }
        protected IVirtualUrlProvider UrlProvider { get; private set; }

        /// <summary>
        /// Should be parameters from context on item model.
        /// Default: true.
        /// </summary>
        protected bool IsBindModel { get; set; }

        public DataSourceProxy(IModelBinder modelBinder, IVirtualUrlProvider urlProvider)
        {
            Guard.NotNull(modelBinder, "modelBinder");
            Guard.NotNull(urlProvider, "urlProvider");
            ModelBinder = modelBinder;
            UrlProvider = urlProvider;
            IsBindModel = true;
        }

        public void GetItem(Action<object> callback, Action<ErrorModel> errorCallback)
        {
            if (!OnGetItem(callback))
            {
                jQuery.ajax(new AjaxSettings
                {
                    url = UrlProvider.ResolveUrl(FormatUrl()),
                    type = "GET",
                    data = SetParametersInternal(),
                    cache = false,
                    success = (object response, JsString status, jqXHR sender) =>
                    {
                        TResultModel model;
                        if (Converts.Try<JsObject, TResultModel>(response.As<JsObject>(), out model))
                        {
                            if (IsBindModel)
                                model = ModelBinder.Bind<TResultModel>(model);

                            callback(model);
                            return;
                        }
                    },
                    error = (response, status, error) =>
                    {
                        errorCallback(new ErrorModel(response.status, response.statusText, response.responseText));
                    }
                });
            }
        }

        private JsObject SetParametersInternal()
        {
            JsObjectBuilder parameterBuilder = JsObjectBuilder.New("DataSource", GetDataSourceName());
            SetParameters(parameterBuilder);
            return parameterBuilder.ToJsObject();
        }

        /// <summary>
        /// Set additional request parameters.
        /// </summary>
        protected abstract void SetParameters(JsObjectBuilder parameterBuilder);

        /// <summary>
        /// On trying to model from this data source.
        /// Called before generation request.
        /// </summary>
        protected abstract bool OnGetItem(Action<object> callback);

        /// <summary>
        /// Returns data source name.
        /// </summary>
        protected virtual string GetDataSourceName()
        {
            return GetType().Name;
        }

        protected virtual string FormatUrl()
        {
            return "~/DataSource.ashx";
        }
    }
}

using Neptuo.TemplateEngine.Web.Controllers.Binders;
using Neptuo.Templates;
using SharpKit.JavaScript;
using SharpKit.jQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.DataSources
{
    public abstract class DataSourceProxy<TResultModel> : IDataSource
    {
        protected IModelBinder ModelBinder { get; private set; }
        protected IVirtualUrlProvider UrlProvider { get; private set; }

        protected bool IsBindModel { get; set; }

        public DataSourceProxy(IModelBinder modelBinder, IVirtualUrlProvider urlProvider)
        {
            Guard.NotNull(modelBinder, "modelBinder");
            Guard.NotNull(urlProvider, "urlProvider");
            ModelBinder = modelBinder;
            UrlProvider = urlProvider;
            IsBindModel = true;
        }

        public void GetItem(Action<object> callback)
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

        protected abstract void SetParameters(JsObjectBuilder parameterBuilder);

        protected abstract bool OnGetItem(Action<object> callback);

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

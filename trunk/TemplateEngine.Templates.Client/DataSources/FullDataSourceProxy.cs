using Neptuo.TemplateEngine.Providers.ModelBinders;
using Neptuo.TemplateEngine.Web;
using Neptuo.Templates;
using SharpKit.JavaScript;
using SharpKit.jQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.DataSources
{
    public abstract class FullDataSourceProxy<TListResultModel, TSingleResultModel> : IClientListDataSource, IClientDataSource
        where TListResultModel : IListResult
    {
        protected IVirtualUrlProvider UrlProvider { get; private set; }
        protected IModelBinder ModelBinder { get; private set; }
        protected IEnumerable<string> ListProperties { get; private set; }
        protected IEnumerable<string> SingleProperties { get; private set; }

        protected bool IsBindModel { get; set; }

        public FullDataSourceProxy(IModelBinder modelBinder, IVirtualUrlProvider urlProvider, IEnumerable<string> parameterProperties, IEnumerable<string> singleProperties)
        {
            Guard.NotNull(modelBinder, "modelBinder");
            Guard.NotNull(urlProvider, "urlProvider");
            ModelBinder = modelBinder;
            UrlProvider = urlProvider;
            IsBindModel = true;
            ListProperties = parameterProperties;
            SingleProperties = singleProperties;
        }

        #region List data source

        public void GetData(int? pageIndex, int? pageSize, Action<IListResult> callback, Action<ErrorModel> errorCallback)
        {
            jQuery.ajax(new AjaxSettings
            {
                url = UrlProvider.ResolveUrl(FormatUrl()),
                type = "GET",
                data = SetListParametersInternal(pageIndex, pageSize),
                cache = false,
                success = (object response, JsString status, jqXHR sender) =>
                {
                    TListResultModel model;
                    if (Converts.Try<JsObject, TListResultModel>(response.As<JsObject>(), out model))
                        callback(model);
                    else
                        throw new NotSupportedException();
                },
                error = (response, status, error) =>
                {
                    errorCallback(new ErrorModel(response.status, response.statusText, response.responseText));
                }
            });
        }

        private JsObject SetListParametersInternal(int? pageIndex, int? pageSize)
        {
            JsObjectBuilder parameterBuilder = JsObjectBuilder.New("DataSource", GetDataSourceName()).Set("IsListMode", true).Set("PageIndex", pageIndex).Set("PageSize", pageSize);
            SetListParameters(parameterBuilder);
            return parameterBuilder.ToJsObject();
        }

        protected virtual void SetListParameters(JsObjectBuilder parameterBuilder)
        {
            if (ListProperties == null)
                throw new InvalidOperationException("Missing ListProperties or overriden method SetListParameters.");

            foreach (string propertyName in ListProperties)
            {
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                object propertyValue = propertyInfo.GetValue(this, null);
                parameterBuilder.Set(propertyName, propertyValue);
            }
        }

        #endregion

        #region Single data source

        public void GetItem(Action<object> callback, Action<ErrorModel> errorCallback)
        {
            if (!OnGetItem(callback))
            {
                jQuery.ajax(new AjaxSettings
                {
                    url = UrlProvider.ResolveUrl(FormatUrl()),
                    type = "GET",
                    data = SetSingleParametersInternal(),
                    cache = false,
                    success = (object response, JsString status, jqXHR sender) =>
                    {
                        TSingleResultModel model;
                        if (Converts.Try<JsObject, TSingleResultModel>(response.As<JsObject>(), out model))
                        {
                            if (IsBindModel)
                                model = ModelBinder.Bind<TSingleResultModel>(model);

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

        private JsObject SetSingleParametersInternal()
        {
            JsObjectBuilder parameterBuilder = JsObjectBuilder.New("DataSource", GetDataSourceName());
            SetSingleParameters(parameterBuilder);
            return parameterBuilder.ToJsObject();
        }

        protected virtual void SetSingleParameters(JsObjectBuilder parameterBuilder)
        {
            if (SingleProperties == null)
                throw new InvalidOperationException("Missing SingleProperties or overriden method SetSingleParameters.");

            foreach (string propertyName in SingleProperties)
            {
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                object propertyValue = propertyInfo.GetValue(this, null);
                parameterBuilder.Set(propertyName, propertyValue);
            }
        }

        protected abstract bool OnGetItem(Action<object> callback);


        #endregion

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

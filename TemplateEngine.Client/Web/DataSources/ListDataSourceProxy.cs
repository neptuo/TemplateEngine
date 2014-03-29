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
    public abstract class ListDataSourceProxy<TResultModel> : IListDataSource
        where TResultModel : IListResult
    {
        private IVirtualUrlProvider urlProvider;

        public ListDataSourceProxy(IVirtualUrlProvider urlProvider)
        {
            Guard.NotNull(urlProvider, "urlProvider");
            this.urlProvider = urlProvider;
        }

        public void GetData(int? pageIndex, int? pageSize, Action<IListResult> callback)
        {
            jQuery.ajax(new AjaxSettings
            {
                url = urlProvider.ResolveUrl(FormatUrl()),
                type = "GET",
                data = SetParametersInternal(pageIndex, pageSize),
                cache = false,
                success = (object response, JsString status, jqXHR sender) =>
                {
                    TResultModel model;
                    if (Converts.Try<JsObject, TResultModel>(response.As<JsObject>(), out model))
                        callback(model);
                    else
                        throw new NotSupportedException();
                }
            });
        }

        private JsObject SetParametersInternal(int? pageIndex, int? pageSize)
        {
            JsObjectBuilder parameterBuilder = JsObjectBuilder.New("DataSource", GetDataSourceName()).Set("PageIndex", pageIndex).Set("PageSize", pageSize);
            SetParameters(parameterBuilder);
            return parameterBuilder.ToJsObject();
        }

        protected abstract void SetParameters(JsObjectBuilder parameterBuilder);

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

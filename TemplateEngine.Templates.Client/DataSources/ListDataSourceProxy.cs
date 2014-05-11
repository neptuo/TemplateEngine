using Neptuo.TemplateEngine.Web;
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
    /// List data source proxy.
    /// Calls web data source with class name and uses <see cref="IConverter"/> to convert response JSON.
    /// </summary>
    /// <typeparam name="TResultModel">Result list type.</typeparam>
    public abstract class ListDataSourceProxy<TResultModel> : IClientListDataSource
        where TResultModel : IListResult
    {
        protected IVirtualUrlProvider UrlProvider { get; private set; }

        public ListDataSourceProxy(IVirtualUrlProvider urlProvider)
        {
            Guard.NotNull(urlProvider, "urlProvider");
            UrlProvider = urlProvider;
        }

        public void GetData(int? pageIndex, int? pageSize, Action<IListResult> callback, Action<ErrorModel> errorCallback)
        {
            jQuery.ajax(new AjaxSettings
            {
                url = UrlProvider.ResolveUrl(FormatUrl()),
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
                },
                error = (response, status, error) =>
                {
                    errorCallback(new ErrorModel(response.status, response.statusText, response.responseText));
                }
            });
        }

        private JsObject SetParametersInternal(int? pageIndex, int? pageSize)
        {
            JsObjectBuilder parameterBuilder = JsObjectBuilder.New("DataSource", GetDataSourceName()).Set("PageIndex", pageIndex).Set("PageSize", pageSize);
            SetParameters(parameterBuilder);
            return parameterBuilder.ToJsObject();
        }

        /// <summary>
        /// Set additional request parameters.
        /// </summary>
        protected abstract void SetParameters(JsObjectBuilder parameterBuilder);

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

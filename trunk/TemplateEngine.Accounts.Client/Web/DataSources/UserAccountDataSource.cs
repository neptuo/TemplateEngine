using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Web.DataSources;
using Neptuo.Templates;
using SharpKit.Html;
using SharpKit.JavaScript;
using SharpKit.jQuery;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Web.DataSources
{
    public class UserAccountDataSource : IListDataSource
    {
        private IVirtualUrlProvider urlProvider;

        public int? Key { get; set; }
        public string Username { get; set; }
        public int? RoleKey { get; set; }

        public UserAccountDataSource(IVirtualUrlProvider urlProvider)
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
                data = JsObjectBuilder
                    .New("DataSource", "UserAccountDataSource")
                    .Set("Key", Key)
                    .Set("Username", Username)
                    .Set("RoleKey", RoleKey)
                    .Set("PageIndex", pageIndex)
                    .Set("PageSize", pageSize)
                    .ToJsObject(),
                cache = false,
                success = (object response, JsString status, jqXHR sender) =>
                {
                    IListResult model;
                    if (Converts.Try<JsObject, IListResult>(response.As<JsObject>(), out model))
                        callback(model);
                    else
                        throw new NotSupportedException();
                }
            });
        }

        protected string FormatUrl()
        {
            return "~/DataSource.ashx";
        }
    }
}

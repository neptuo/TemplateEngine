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
    public class UserAccountDataSource : ListDataSourceProxy<UserAccountListResult>
    {
        //private IVirtualUrlProvider urlProvider;

        public int? Key { get; set; }
        public string Username { get; set; }
        public int? RoleKey { get; set; }

        public UserAccountDataSource(IVirtualUrlProvider urlProvider)
            : base(urlProvider)
        {
            //Guard.NotNull(urlProvider, "urlProvider");
            //this.urlProvider = urlProvider;
        }

        //public void GetData(int? pageIndex, int? pageSize, Action<IListResult> callback)
        //{
        //    jQuery.ajax(new AjaxSettings
        //    {
        //        url = urlProvider.ResolveUrl(FormatUrl()),
        //        type = "GET",
        //        data = JsObjectBuilder
        //            .New("DataSource", "UserAccountDataSource")
        //            .Set("Key", Key)
        //            .Set("Username", Username)
        //            .Set("RoleKey", RoleKey)
        //            .Set("PageIndex", pageIndex)
        //            .Set("PageSize", pageSize)
        //            .ToJsObject(),
        //        cache = false,
        //        success = (object response, JsString status, jqXHR sender) =>
        //        {
        //            UserAccountListResult model;
        //            if (Converts.Try<JsObject, UserAccountListResult>(response.As<JsObject>(), out model))
        //                callback(model);
        //            else
        //                throw new NotSupportedException();
        //        }
        //    });
        //}

        //protected string FormatUrl()
        //{
        //    return "~/DataSource.ashx";
        //}

        protected override void SetParameters(JsObjectBuilder parameterBuilder)
        {
            parameterBuilder
                .Set("Key", Key)
                .Set("Username", Username)
                .Set("RoleKey", RoleKey);
        }
    }
}

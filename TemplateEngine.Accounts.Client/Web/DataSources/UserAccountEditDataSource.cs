using Neptuo.PresentationModels;
using Neptuo.PresentationModels.TypeModels;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Web.Controllers.Binders;
using Neptuo.TemplateEngine.Web.DataSources;
using Neptuo.Templates;
using SharpKit.Html;
using SharpKit.JavaScript;
using SharpKit.jQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Web.DataSources
{
    public class UserAccountEditDataSource : IDataSource
    {
        private int key;
        private IModelBinder modelBinder;
        private IVirtualUrlProvider urlProvider;

        public int Key
        {
            get { return key; }
            set
            {
                if (value.As<object>() != null)
                    key = value;
            }
        }

        public UserAccountEditDataSource(IModelBinder modelBinder, IVirtualUrlProvider urlProvider)
        {
            Guard.NotNull(modelBinder, "modelBinder");
            Guard.NotNull(urlProvider, "urlProvider");
            this.modelBinder = modelBinder;
            this.urlProvider = urlProvider;
        }

        public void GetItem(Action<object> callback)
        {
            if (Key == 0)
            {
                UserAccountEditModel model = new UserAccountEditModel { Key = 0, IsEnabled = true };
                model = modelBinder.Bind<UserAccountEditModel>(model);

                callback(model);
                return;
            }

            jQuery.ajax(new AjaxSettings
            {
                url = urlProvider.ResolveUrl(FormatUrl()),
                type = "GET",
                data = JsObjectBuilder.New("DataSource", "UserAccountEditDataSource").Set("Key", Key).ToJsObject(),
                cache = false,
                success = (object response, JsString status, jqXHR sender) =>
                {
                    UserAccountEditModel model;
                    if (Converts.Try<JsObject, UserAccountEditModel>(response.As<JsObject>(), out model))
                    {
                        model = modelBinder.Bind<UserAccountEditModel>(model);
                        callback(model);
                        return;
                    }
                }
            });

        }

        protected string FormatUrl()
        {
            return "~/DataSource.ashx";
            //return String.Format("~/DataSource.ashx?DataSource={0}&Key={1}", "UserAccountEditDataSource", Key);
        }
    }
}

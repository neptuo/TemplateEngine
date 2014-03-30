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
    public class UserAccountEditDataSource : DataSourceProxy<UserAccountEditModel>
    {
        private int key;

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
            : base(modelBinder, urlProvider)
        { }

        protected override void SetParameters(JsObjectBuilder parameterBuilder)
        {
            parameterBuilder
                .Set("Key", Key);
        }

        protected override bool OnGetItem(Action<object> callback)
        {
            if (Key == 0)
            {
                UserAccountEditModel model = new UserAccountEditModel() { Key = 0 };
                model = ModelBinder.Bind<UserAccountEditModel>(model);

                callback(model);
                return true;
            }
            return false;
        }
    }
}

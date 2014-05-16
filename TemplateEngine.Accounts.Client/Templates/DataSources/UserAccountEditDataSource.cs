using Neptuo.PresentationModels;
using Neptuo.PresentationModels.TypeModels;
using Neptuo.TemplateEngine.Providers.ModelBinders;
using Neptuo.TemplateEngine.Templates.DataSources;
using Neptuo.Templates;
using SharpKit.Html;
using SharpKit.JavaScript;
using SharpKit.jQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Templates.DataSources
{
    public class UserAccountEditDataSource : DataSourceProxy<UserAccountEditModel>
    {
        public int? Key { get; set; }

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
                UserAccountEditModel model = BindModelIfRequired(new UserAccountEditModel());
                callback(model);
                return true;
            }
            return false;
        }
    }
}

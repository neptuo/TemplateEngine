using Neptuo.TemplateEngine.Providers.ModelBinders;
using Neptuo.TemplateEngine.Templates.DataSources;
using Neptuo.Templates;
using SharpKit.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Templates.DataSources
{
    public class UserRoleEditDataSource : DataSourceProxy<UserRoleEditModel>
    {
        public int? Key { get; set; }

        public UserRoleEditDataSource(IModelBinder modelBinder, IVirtualUrlProvider urlProvider)
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
                UserRoleEditModel model = BindModelIfRequired(new UserRoleEditModel());
                callback(model);
                return true;
            }
            return false;
        }
    }
}

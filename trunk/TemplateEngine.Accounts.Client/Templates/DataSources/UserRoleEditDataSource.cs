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
                callback(new UserRoleEditModel());
                return true;
            }

            return false;
        }
    }
}

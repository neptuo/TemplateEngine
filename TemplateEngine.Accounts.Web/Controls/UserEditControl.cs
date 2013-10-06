using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Web.Controls;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Web.Controls
{
    [Html("form")]
    public class UserEditControl : BaseContentControl
    {
        protected IUserAccountRepository UserAccounts { get; private set; }
        protected UserAccount UserAccount { get; private set; }
        public int? UserKey { get; set; }

        public UserEditControl(IComponentManager componentManager, IUserAccountRepository userAccounts)
            : base(componentManager)
        {
            UserAccounts = userAccounts;
        }

        public override void OnInit()
        {
            if (UserKey != null)
                UserAccount = UserAccounts.Get(UserKey.Value) ?? UserAccounts.Create();
            else
                UserAccount = UserAccounts.Create();

            base.OnInit();
        }
    }
}

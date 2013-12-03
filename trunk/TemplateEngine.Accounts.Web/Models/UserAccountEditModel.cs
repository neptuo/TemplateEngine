using Neptuo.TemplateEngine.Accounts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Web.Models
{
    public class UserAccountEditModel : EditUserCommand
    {
        public bool IsNew
        {
            get { return Key == 0; }
        }

        public UserAccountEditModel()
        { }

        public UserAccountEditModel(UserAccount userAccount)
            : base(userAccount)
        { }
    }
}

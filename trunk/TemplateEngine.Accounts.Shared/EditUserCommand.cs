using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class EditUserCommand
    {
        public int Key { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordAgain { get; set; }
        public bool IsEnabled { get; set; }

        public EditUserCommand()
        { }

        //public EditUserCommand(UserAccount userAccount)
        //{
        //    if (userAccount != null)
        //    {
        //        Key = userAccount.Key;
        //        Username = userAccount.Username;
        //        IsEnabled = userAccount.IsEnabled;
        //    }
        //}
    }
}

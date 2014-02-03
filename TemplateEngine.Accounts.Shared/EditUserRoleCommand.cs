using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class EditUserRoleCommand
    {
        public int Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public EditUserRoleCommand()
        { }

        //public EditUserRoleCommand(UserRole userRole)
        //{
        //    if (userRole == null)
        //        throw new ArgumentNullException("userRole");

        //    Key = userRole.Key;
        //    Name = userRole.Name;
        //    Description = userRole.Description;
        //}
    }
}

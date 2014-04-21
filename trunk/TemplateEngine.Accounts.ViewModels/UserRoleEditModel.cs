using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class UserRoleEditModel
    {
        public bool IsNew
        {
            get { return Key == 0; }
        }

        public int Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public UserRoleEditModel()
        { }
    }
}

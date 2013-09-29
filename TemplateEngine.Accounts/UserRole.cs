using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public abstract class UserRole
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}

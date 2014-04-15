using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Security
{
    public interface IAuthenticator
    {
        bool Login(string username, string password);
        bool Logout();
    }
}

using Neptuo.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class PasswordProvider
    {
        public static string ComputePassword(string username, string password)
        {
            return HashHelper.Sha1(String.Join(".", username, password));
        }
    }
}

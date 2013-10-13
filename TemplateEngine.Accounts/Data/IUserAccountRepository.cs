using Neptuo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data
{
    public interface IUserAccountRepository : IRepository<UserAccount, int>, IActivator<UserAccount>
    { }
}

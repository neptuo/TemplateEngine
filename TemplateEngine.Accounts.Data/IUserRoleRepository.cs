using Neptuo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data
{
    public interface IUserRoleRepository : IRepository<UserRole, int>, IActivator<UserRole>
    { }
}

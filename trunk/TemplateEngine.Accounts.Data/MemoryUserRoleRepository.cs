using Neptuo.Data;
using Neptuo.TemplateEngine.Accounts.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data
{
    public class MemoryUserRoleRepository : IUserRoleRepository, IDeprecatedUserRoleQuery
    {
        private int newId = 0;
        private Dictionary<int, UserRole> storage = new Dictionary<int, UserRole>();

        public UserRole Get(int id)
        {
            UserRole role;
            if (storage.TryGetValue(id, out role))
                return role;

            return null;
        }

        public IEnumerable<UserRole> Get()
        {
            return storage.Values;
        }

        public IEnumerable<UserRole> Get(int pageIndex, int pageSize)
        {
            return storage.Values.Skip(pageIndex * pageSize).Take(pageSize);
        }

        public void Delete(UserRole item)
        {
            storage.Remove(item.Key);
        }

        public void Insert(UserRole item)
        {
            item.Key = ++newId;
            storage[item.Key] = item;
        }

        public void Update(UserRole item)
        {
            storage[item.Key] = item;
        }

        public UserRole Create()
        {
            return new MemoryUserRole();
        }
    }

    public class MemoryUserRole : UserRole
    { }
}

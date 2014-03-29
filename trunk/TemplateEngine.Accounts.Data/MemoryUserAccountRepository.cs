using Neptuo.Data;
using Neptuo.TemplateEngine.Accounts.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data
{
    public class MemoryUserAccountRepository : IUserAccountRepository, IUserAccountQuery
    {
        private int newId = 0;
        private Dictionary<int, UserAccount> storage = new Dictionary<int, UserAccount>();

        public UserAccount Get(Key key)
        {
            return Get(key.ID);
        }

        public IEnumerable<UserAccount> Get()
        {
            return storage.Values;
        }

        public IEnumerable<UserAccount> Get(int pageIndex, int pageSize)
        {
            return storage.Values.Skip(pageIndex * pageSize).Take(pageSize);
        }

        public void Delete(UserAccount item)
        {
            storage.Remove(item.Key);
        }

        public UserAccount Get(int id)
        {
            UserAccount account;
            if (storage.TryGetValue(id, out account))
                return account;

            return null;
        }

        public void Insert(UserAccount item)
        {
            item.Key = ++newId;
            storage[item.Key] = item;
        }

        public void Update(UserAccount item)
        {
            storage[item.Key] = item;
        }

        public UserAccount Create()
        {
            return new MemoryUserAccount();
        }

        public UserAccount Get(string username, string password)
        {
            return storage.Values.FirstOrDefault(u => u.Username == username && u.Password == password && u.IsEnabled);
        }
    }

    public class MemoryUserAccount : UserAccount
    {
        public override List<UserRole> Roles { get; set; }

        public MemoryUserAccount()
        {
            Roles = new List<UserRole>();
        }
    }

}

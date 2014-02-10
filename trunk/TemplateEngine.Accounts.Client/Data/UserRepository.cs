using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data
{
    public class UserRepository
    {
        private List<UserAccountEditModel> data;

        public UserRepository()
        {
            data = new List<UserAccountEditModel>();
            for (int i = 0; i < 34; i++)
            {
                data.Add(new UserAccountEditModel 
                {
                    Key = i + 1,
                    Username = "User " + i,
                    IsEnabled = (i % 3) == 1
                });
            };
        }

        public List<UserAccountEditModel> GetPage(int pageIndex, int pageSize)
        {
            return data.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }

        public List<UserAccountEditModel> GetAll()
        {
            return data;
        }

        public void Add(UserAccountEditModel userAccount)
        {
            data.Add(userAccount);
        }

        public int GetCount()
        {
            return data.Count;
        }
    }
}

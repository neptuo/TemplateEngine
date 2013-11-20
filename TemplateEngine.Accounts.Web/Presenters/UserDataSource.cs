using Neptuo.Data;
using Neptuo.PresentationModels.TypeModels;
using Neptuo.TemplateEngine.Accounts.Queries;
using Neptuo.TemplateEngine.Web;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Web.Presenters
{
    public class UserDataSource : IDataSource
    {
        private IUserQuery userQuery;
        private IModelValueProviderFactory factory;

        public int? Key { get; set; }

        public UserDataSource(IUserQuery userQuery, IModelValueProviderFactory factory)
        {
            this.userQuery = userQuery;
            this.factory = factory;
        }

        public IEnumerable GetData()
        {
            foreach (UserAccount userAccount in userQuery.Get())
                yield return factory.Create(userAccount);
        }

        public object GetItem()
        {
            UserAccount userAccount = null;
            if (Key != null)
                userAccount = userQuery.Get(Key.Value);
            else
                userQuery.Get().FirstOrDefault();

            if (userAccount == null)
                return null;

            return factory.Create(userAccount);
        }
    }
}

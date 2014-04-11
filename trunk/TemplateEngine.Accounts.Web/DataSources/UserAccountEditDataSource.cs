using Neptuo.Data;
using Neptuo.Data.Queries;
using Neptuo.PresentationModels.TypeModels;
using Neptuo.TemplateEngine.Accounts.Commands;
using Neptuo.TemplateEngine.Accounts.Data.Queries;
using Neptuo.TemplateEngine.Accounts.Queries;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Web.Controllers.Binders;
using Neptuo.TemplateEngine.Web.DataSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Web.DataSources
{
    [WebDataSource]
    public class UserAccountEditDataSource : IDataSource
    {
        private IUserAccountQuery userQuery;
        private IActivator<UserAccount> userFactory;
        private IModelValueProviderFactory providerFactory;
        private IModelBinder modelBinder;

        public int Key { get; set; }

        public UserAccountEditDataSource(IUserAccountQuery userQuery, IActivator<UserAccount> userFactory, IModelValueProviderFactory providerFactory, IModelBinder modelBinder)
        {
            this.userQuery = userQuery;
            this.userFactory = userFactory;
            this.providerFactory = providerFactory;
            this.modelBinder = modelBinder;
        }

        public object GetItem()
        {
            userQuery.Filter.Key = IntSearch.Create(Key);

            UserAccountEditModel model = MapEntityToModel(userQuery.ResultSingle() ?? userFactory.Create());
            model = modelBinder.Bind<UserAccountEditModel>(model);
            return model;
            //return providerFactory.Create(model);
        }

        private UserAccountEditModel MapEntityToModel(UserAccount userAccount)
        {
            return new UserAccountEditModel
            {
                Key = userAccount.Key,
                Username = userAccount.Username,
                IsEnabled = userAccount.IsEnabled,
                RoleKeys = GetRoles(userAccount)
            };
        }

        private IEnumerable<int> GetRoles(UserAccount account)
        {
            if (account.Roles == null)
                return Enumerable.Empty<int>();

            return account.Roles.Select(r => r.Key);
        }
    }
}

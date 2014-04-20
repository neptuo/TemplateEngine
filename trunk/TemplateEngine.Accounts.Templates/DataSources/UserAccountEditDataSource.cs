using Neptuo.Data;
using Neptuo.Data.Queries;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Providers.ModelBinders;
using Neptuo.TemplateEngine.Templates.DataSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neptuo.TemplateEngine.Templates.DataSources;

namespace Neptuo.TemplateEngine.Accounts.Templates.DataSources
{
    [WebDataSource]
    public class UserAccountEditDataSource : IDataSource
    {
        private UserAccountDataProvider dataService;
        private IModelBinder modelBinder;

        public int Key { get; set; }

        public UserAccountEditDataSource(UserAccountDataProvider dataService, IModelBinder modelBinder)
        {
            Guard.NotNull(dataService, "accountDataService");
            Guard.NotNull(modelBinder, "modelBinder");
            this.dataService = dataService;
            this.modelBinder = modelBinder;
        }

        public object GetItem()
        {
            UserAccount account = dataService.Repository.Get(Key);

            UserAccountEditModel model = MapEntityToModel(account ?? dataService.Factory.Create());
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

using Neptuo.Data;
using Neptuo.Data.Queries;
using Neptuo.PresentationModels.TypeModels;
using Neptuo.TemplateEngine.Accounts.Commands;
using Neptuo.TemplateEngine.Accounts.Data;
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
        private UserAccountDataService dataService;
        private IModelBinder modelBinder;

        public int Key { get; set; }

        public UserAccountEditDataSource(UserAccountDataService dataService, IModelBinder modelBinder)
        {
            Guard.NotNull(dataService, "accountDataService");
            Guard.NotNull(modelBinder, "modelBinder");
            this.dataService = dataService;
            this.modelBinder = modelBinder;
        }

        public object GetItem()
        {
            dataService.Query.Filter.Key = IntSearch.Create(Key);

            UserAccount account1 = dataService.Query.Result().Items.ToList().FirstOrDefault();
            UserAccount account2 = dataService.Repository.Get(Key);

            UserAccountEditModel model1 = MapEntityToModel(account1 ?? dataService.Factory.Create());
            UserAccountEditModel model2 = MapEntityToModel(account2 ?? dataService.Factory.Create());
            model1 = modelBinder.Bind<UserAccountEditModel>(model1);
            return model1;
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

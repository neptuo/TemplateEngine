using Neptuo.Data;
using Neptuo.PresentationModels.TypeModels;
using Neptuo.TemplateEngine.Accounts.Commands;
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
        private IDeprecatedUserAccountQuery userQuery;
        private IActivator<UserAccount> userFactory;
        private IModelValueProviderFactory providerFactory;
        private IModelBinder modelBinder;

        public int Key { get; set; }

        public UserAccountEditDataSource(IDeprecatedUserAccountQuery userQuery, IActivator<UserAccount> userFactory, IModelValueProviderFactory providerFactory, IModelBinder modelBinder)
        {
            this.userQuery = userQuery;
            this.userFactory = userFactory;
            this.providerFactory = providerFactory;
            this.modelBinder = modelBinder;
        }

        public object GetItem()
        {
            UserAccountEditModel model = MapEntityToModel(userQuery.Get(Key) ?? userFactory.Create());
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
                RoleKeys = userAccount.Roles.Select(r => r.Key)
            };
        }
    }
}

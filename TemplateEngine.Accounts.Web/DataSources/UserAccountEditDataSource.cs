using Neptuo.Data;
using Neptuo.PresentationModels.TypeModels;
using Neptuo.TemplateEngine.Accounts.Commands;
using Neptuo.TemplateEngine.Accounts.Queries;
using Neptuo.TemplateEngine.Accounts.Web.Models;
using Neptuo.TemplateEngine.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Web.DataSources
{
    public class UserAccountEditDataSource : IDataSource
    {
        private IUserAccountQuery userQuery;
        private IActivator<UserAccount> userFactory;
        private IModelValueProviderFactory providerFactory;

        public int Key { get; set; }

        public UserAccountEditDataSource(IUserAccountQuery userQuery, IActivator<UserAccount> userFactory, IModelValueProviderFactory providerFactory)
        {
            this.userQuery = userQuery;
            this.userFactory = userFactory;
            this.providerFactory = providerFactory;
        }

        public object GetItem()
        {
            UserAccountEditModel model = new UserAccountEditModel(userQuery.Get(Key) ?? userFactory.Create());
            return providerFactory.Create(model);
        }
    }
}

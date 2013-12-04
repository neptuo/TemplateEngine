using Neptuo.PresentationModels.TypeModels;
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
    public class UserRoleEditDataSource : IDataSource
    {
        private IUserRoleQuery roleQuery;
        private IActivator<UserRole> roleFactory;
        private IModelValueProviderFactory providerFactory;

        public int Key { get; set; }

        public UserRoleEditDataSource(IUserRoleQuery roleQuery, IActivator<UserRole> roleFactory, IModelValueProviderFactory providerFactory)
        {
            if (roleQuery == null)
                throw new ArgumentNullException("roleQuery");

            this.roleQuery = roleQuery;
            this.roleFactory = roleFactory;
            this.providerFactory = providerFactory;
        }

        public object GetItem()
        {
            UserRoleEditModel model = new UserRoleEditModel(roleQuery.Get(Key) ?? roleFactory.Create());
            return providerFactory.Create(model);
        }
    }
}

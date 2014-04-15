using Neptuo.Data.Queries;
using Neptuo.PresentationModels.TypeModels;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Accounts.Data.Queries;
using Neptuo.TemplateEngine.Providers.ModelBinders;
using Neptuo.TemplateEngine.Templates.DataSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neptuo.TemplateEngine.Web.DataSources;

namespace Neptuo.TemplateEngine.Accounts.Templates.DataSources
{
    [WebDataSource]
    public class UserRoleEditDataSource : IDataSource
    {
        private IUserRoleQuery roleQuery;
        private IActivator<UserRole> roleFactory;
        private IModelBinder modelBinder;

        public int Key { get; set; }

        public UserRoleEditDataSource(IUserRoleQuery roleQuery, IActivator<UserRole> roleFactory, IModelBinder modelBinder)
        {
            if (roleQuery == null)
                throw new ArgumentNullException("roleQuery");

            this.roleQuery = roleQuery;
            this.roleFactory = roleFactory;
            this.modelBinder = modelBinder;
        }

        public object GetItem()
        {
            roleQuery.Filter.Key = IntSearch.Create(Key);

            UserRoleEditModel model = MapEntityToModel(roleQuery.ResultSingle() ?? roleFactory.Create());
            model = modelBinder.Bind<UserRoleEditModel>(model);

            return model;
        }

        private UserRoleEditModel MapEntityToModel(UserRole userRole)
        {
            return new UserRoleEditModel
            {
                Key = userRole.Key,
                Name = userRole.Name,
                Description = userRole.Description
            };
        }
    }
}

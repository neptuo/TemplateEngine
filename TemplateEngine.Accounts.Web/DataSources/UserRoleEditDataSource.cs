using Neptuo.PresentationModels.TypeModels;
using Neptuo.TemplateEngine.Accounts.Queries;
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
            UserRoleEditModel model = MapEntityToModel(roleQuery.Get(Key) ?? roleFactory.Create());
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

using Neptuo.Data.Queries;
using Neptuo.TemplateEngine.Accounts.Data.Queries;
using Neptuo.TemplateEngine.Accounts.ViewModels;
using Neptuo.TemplateEngine.Navigation;
using Neptuo.TemplateEngine.Templates.DataSources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Templates.DataSources
{
    [WebDataSource]
    public class ResourcePermissionDataSource : IListDataSource
    {
        private IResourcePermissionQuery query;

        public int RoleKey { get; set; }

        public ResourcePermissionDataSource(IResourcePermissionQuery query)
        {
            Guard.NotNull(query, "query");
            this.query = query;
        }

        protected void ApplyFilter()
        {
            query.Filter.RoleKey = IntSearch.Create(RoleKey);
        }

        public IEnumerable GetData(int? pageIndex, int? pageSize)
        {
            ApplyFilter();
            var enabledItems = query.EnumerateItems(p => new { ResourceName = p.ResourceName, PermissionName = p.PermissionName });

            List<ResourcePermissionEditViewModel> result = new List<ResourcePermissionEditViewModel>();
            foreach (FormUri formUri in FormUriTable.Repository.EnumerateForms())
            {
                result.Add(new ResourcePermissionEditViewModel(formUri.Identifier(), formUri.Url(), new List<PermissionNameEditViewModel>
                {
                    new PermissionNameEditViewModel(formUri.Identifier(), "Read", true),
                    new PermissionNameEditViewModel(formUri.Identifier(), "ReadWrite", false)
                }));
            }
            return result;
        }

        public int GetTotalCount()
        {
            ApplyFilter();
            return query.Count();
        }
    }
}

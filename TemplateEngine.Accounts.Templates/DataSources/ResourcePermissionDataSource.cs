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
    public class ResourcePermissionDataSource : IListDataSource, IResourcePermissionDataSourceFilter
    {
        private IResourcePermissionQuery query;

        public int? RoleKey { get; set; }
        public string ResourceName { get; set; }
        public string PermissionName { get; set; }

        public ResourcePermissionDataSource(IResourcePermissionQuery query)
        {
            Guard.NotNull(query, "query");
            this.query = query;
        }

        protected bool ApplyFilter()
        {
            if (RoleKey == null)
                return false;

            query.Filter.RoleKey = IntSearch.Create(RoleKey.Value);

            if (ResourceName != null)
                query.Filter.ResourceName = TextSearch.Create(ResourceName, TextSearchType.Contains);

            if (PermissionName != null)
                query.Filter.PermissionName = TextSearch.Create(PermissionName, TextSearchType.Contains);

            return true;
        }

        protected IEnumerable<FormUri> GetFormUris()
        {
            IEnumerable<FormUri> result = FormUriTable.Repository.EnumerateForms();

            if (ResourceName != null)
                result = result.Where(f => f.Identifier().Contains(ResourceName));

            return result;
        }

        protected IEnumerable<string> GetPermissions()
        {
            IEnumerable<string> result = new List<string> { "Read", "ReadWrite" };

            if (PermissionName != null)
                result = result.Where(p => p.Contains(PermissionName));

            return result;
        }

        public IEnumerable GetData(int? pageIndex, int? pageSize)
        {
            List<ResourcePermissionEditViewModel> result = new List<ResourcePermissionEditViewModel>();
            if (ApplyFilter())
            {
                var enabledItems = query.EnumerateItems(p => new { ResourceName = p.ResourceName, PermissionName = p.PermissionName });

                foreach (FormUri formUri in GetFormUris())
                {
                    result.Add(
                        new ResourcePermissionEditViewModel(
                            formUri.Identifier(), 
                            formUri.Url(), 
                            GetPermissions().Select(p => new PermissionNameEditViewModel(formUri.Identifier(), p, true))
                        )
                    );
                }
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

using Neptuo.PresentationModels.TypeModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.DataSources
{
    public abstract class ListDataSourceBase<T> : IListDataSource
    {
        protected IModelValueProviderFactory ProviderFactory { get; private set; }

        public ListDataSourceBase(IModelValueProviderFactory providerFactory)
        {
            if (providerFactory == null)
                throw new ArgumentNullException("providerFactory");

            ProviderFactory = providerFactory;
        }

        protected abstract IQueryable<T> GetData();

        protected abstract IQueryable<T> ApplyFilter(IQueryable<T> data);

        public IEnumerable GetData(int? pageIndex, int? pageSize)
        {
            IQueryable<T> data = GetData();

            data = ApplyFilter(data);

            if (pageSize != null)
                data = data.Skip((pageIndex ?? 0) * pageSize.Value).Take(pageSize.Value);

            foreach (T item in data)
                yield return ProviderFactory.Create(item);
        }

        public int GetTotalCount()
        {
            IQueryable<T> data = GetData();
            data = ApplyFilter(data);
            return data.Count();
        }
    }
}

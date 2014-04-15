using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data
{
    public abstract class DataProviderBase<TModel, TQuery, TRepository>
    {
        protected IActivator<TQuery> QueryFactory { get; private set; }
        public TRepository Repository { get; private set; }
        public IActivator<TModel> Factory { get; private set; }

        public DataProviderBase(TRepository repository, IActivator<TQuery> queryFactory, IActivator<TModel> modelFactory)
        {
            Guard.NotNull(repository, "repository");
            Guard.NotNull(queryFactory, "queryFactory");
            Guard.NotNull(modelFactory, "modelFactory");
            Repository = repository;
            QueryFactory = queryFactory;
            Factory = modelFactory;
        }

        public TQuery Query()
        {
            return QueryFactory.Create();
        }
    }
}

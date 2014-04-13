using Neptuo.PresentationModels;
using Neptuo.PresentationModels.TypeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates
{
    public class PresentationConfiguration
    {
        public TemplateContentStorageStack TemplateStorage { get; protected set; }
        public IModelValueProviderFactory ValueProviderFactory { get; protected set; }
        public DataContextStorage DataContext { get; protected set; }

        public PresentationConfiguration(TemplateContentStorageStack templateStorage, IModelValueProviderFactory valueProviderFactory, DataContextStorage dataContext)
        {
            if (templateStorage == null)
                throw new ArgumentNullException("templateStorage");

            if (valueProviderFactory == null)
                throw new ArgumentNullException("valueProviderFactory");

            if (dataContext == null)
                throw new ArgumentNullException("dataContext");

            TemplateStorage = templateStorage;
            ValueProviderFactory = valueProviderFactory;
            DataContext = dataContext;
        }
    }

    public class PresentationConfiguration<T> : PresentationConfiguration
    {
        public PresentationConfiguration(TemplateContentStorageStack templateStorage, IModelValueProviderFactory valueProviderFactory, DataContextStorage dataContext)
            : base(templateStorage, valueProviderFactory, dataContext)
        { }
    }
}

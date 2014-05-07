using Neptuo.PresentationModels;
using Neptuo.TemplateEngine.Providers.ModelBinders;
using Neptuo.TemplateEngine.Publishing.ViewModels;
using Neptuo.TemplateEngine.Templates.DataSources;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.Templates.DataSources
{
    public class ArticleTagDataSource : FullDataSourceProxy<ModelValueGetterListResult, ArticleTagViewModel>, IArticleTagDataSourceFilter
    {
        public IEnumerable<int> Key { get; set; }
        public string Name { get; set; }
        public string UrlPart { get; set; }

        public ArticleTagDataSource(IModelBinder modelBinder, IVirtualUrlProvider urlProvider)
            : base(modelBinder, urlProvider, GetFilterListProperties(), GetFilterSingleProperties())
        { }

        private static IEnumerable<string> GetFilterListProperties()
        {
            return new List<string> { "Key", "Name", "UrlPart" };
        }

        private static IEnumerable<string> GetFilterSingleProperties()
        {
            return new List<string> { "Key" };
        }

        protected override bool OnGetItem(Action<object> callback)
        {
            if (Key == null)
            {
                ArticleTagViewModel model = new ArticleTagViewModel();
                model = ModelBinder.Bind<ArticleTagViewModel>(model);

                callback(model);
                return true;
            }
            return false;
        }
    }
}

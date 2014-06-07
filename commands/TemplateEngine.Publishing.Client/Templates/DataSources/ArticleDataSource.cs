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
    public class ArticleDataSource : FullDataSourceProxy<ArticleListResult, ArticleEditViewModel>, IArticleDataSourceFilter
    {
        public int? Key { get; set; }
        public int? LineKey { get; set; }
        public int? TagKey { get; set; }
        public bool IsIncludeHidden { get; set; }
        
        public string Title { get; set; }
        public string UrlPart { get; set; }

        public ArticleDataSource(IModelBinder modelBinder, IVirtualUrlProvider urlProvider)
            : base(modelBinder, urlProvider, GetFilterListProperties(), GetFilterSingleProperties())
        { }

        private static IEnumerable<string> GetFilterListProperties()
        {
            return new List<string> { "Key", "LineKey", "TagKey", "IsIncludeHidden", "Title", "UrlPart" };
        }

        private static IEnumerable<string> GetFilterSingleProperties()
        {
            return new List<string> { "Key" };
        }

        protected override bool OnGetItem(Action<object> callback)
        {
            if (Key == null)
            {
                ArticleLineEditViewModel model = new ArticleLineEditViewModel();
                model = ModelBinder.Bind<ArticleLineEditViewModel>(model);

                callback(model);
                return true;
            }
            return false;
        }
    }
}

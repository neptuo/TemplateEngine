using Neptuo.ComponentModel.Converters;
using Neptuo.TemplateEngine.Publishing.ViewModels;
using SharpKit.JavaScript;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing
{
    public class ArticleListResultConverter : ListResultConverterBase<ArticleListResult, ArticleViewModel>
    {
        protected override bool TryConvertItem(JsObject sourceValue, out ArticleViewModel item)
        {
            return Converts.Try(sourceValue, out item);
        }

        protected override ArticleListResult CreateResult(IEnumerable data, int totalCount)
        {
            return new ArticleListResult(data, totalCount);
        }
    }
}

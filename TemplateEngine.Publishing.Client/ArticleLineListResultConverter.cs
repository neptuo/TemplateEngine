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
    public class ArticleLineListResultConverter : ListResultConverterBase<ArticleLineListResult, ArticleLineViewModel>
    {
        protected override bool TryConvertItem(JsObject sourceValue, out ArticleLineViewModel item)
        {
            return Converts.Try(sourceValue, out item);
        }

        protected override ArticleLineListResult CreateResult(IEnumerable data, int totalCount)
        {
            return new ArticleLineListResult(data, totalCount);
        }
    }
}

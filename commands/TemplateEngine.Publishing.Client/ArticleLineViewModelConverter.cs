using Neptuo.ComponentModel.Converters;
using Neptuo.TemplateEngine.Publishing.ViewModels;
using SharpKit.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing
{
    public class ArticleLineViewModelConverter : ConverterBase<JsObject, ArticleLineViewModel>
    {
        public override bool TryConvert(JsObject sourceValue, out ArticleLineViewModel targetValue)
        {
            targetValue = new ArticleLineViewModel();
            targetValue.Key = sourceValue["Key"].As<int>();
            targetValue.Name = sourceValue["Name"].As<string>();
            targetValue.UrlPart = sourceValue["UrlPart"].As<string>();
            return true;
        }
    }
}

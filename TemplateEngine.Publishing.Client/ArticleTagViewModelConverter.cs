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
    public class ArticleTagViewModelConverter : ConverterBase<JsObject, ArticleTagViewModel>
    {
        public override bool TryConvert(JsObject sourceValue, out ArticleTagViewModel targetValue)
        {
            targetValue = new ArticleTagViewModel();
            targetValue.Key = sourceValue["Key"].As<int>();
            targetValue.Name = sourceValue["Name"].As<string>();
            targetValue.UrlPart = sourceValue["UrlPart"].As<string>();
            return true;
        }
    }
}

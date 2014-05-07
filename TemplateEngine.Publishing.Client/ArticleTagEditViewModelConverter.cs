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
    public class ArticleTagEditViewModelConverter : ConverterBase<JsObject, ArticleTagEditViewModel>
    {
        public override bool TryConvert(JsObject sourceValue, out ArticleTagEditViewModel targetValue)
        {
            targetValue = new ArticleTagEditViewModel();
            targetValue.Key = sourceValue["Key"].As<int>();
            targetValue.Name = sourceValue["Name"].As<string>();
            targetValue.UrlPart = sourceValue["UrlPart"].As<string>();
            return true;
        }
    }
}

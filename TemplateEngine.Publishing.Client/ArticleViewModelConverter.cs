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
    public class ArticleViewModelConverter : ConverterBase<JsObject, ArticleViewModel>
    {
        public override bool TryConvert(JsObject sourceValue, out ArticleViewModel targetValue)
        {
            targetValue = new ArticleViewModel();
            targetValue.Key = sourceValue["Key"].As<int>();
            targetValue.Title = sourceValue["Title"].As<string>();
            targetValue.UrlPart = sourceValue["UrlPart"].As<string>();
            targetValue.Content = sourceValue["Content"].As<string>();
            return true;
        }
    }
}

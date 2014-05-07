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
    public class ArticleEditViewModelConverter : ConverterBase<JsObject, ArticleEditViewModel>
    {
        public override bool TryConvert(JsObject sourceValue, out ArticleEditViewModel targetValue)
        {
            targetValue = new ArticleEditViewModel();
            targetValue.Key = sourceValue["Key"].As<int>();
            targetValue.Title = sourceValue["Title"].As<string>();
            targetValue.UrlPart = sourceValue["UrlPart"].As<string>();
            targetValue.Content = sourceValue["Content"].As<string>();
            targetValue.IsVisible = sourceValue["IsVisible"].As<bool>();
            targetValue.Author = sourceValue["Author"].As<string>();
            targetValue.LineKey = sourceValue["LineKey"].As<int>();
            targetValue.TagKeys = new List<int>(sourceValue["TagKeys"].As<int[]>());
            return true;
        }
    }
}

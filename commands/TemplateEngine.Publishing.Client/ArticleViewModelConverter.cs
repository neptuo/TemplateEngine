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
            targetValue.IsVisible = sourceValue["IsVisible"].As<bool>();
            targetValue.Author = sourceValue["Author"].As<string>();
            targetValue.Created = sourceValue["Created"].As<DateTime>();
            targetValue.LastModified = sourceValue["LastModified"].As<DateTime?>();

            JsObject lineValue = sourceValue["Line"].As<JsObject>();
            ArticleLineViewModel line;
            if (Converts.Try(lineValue, out line))
                targetValue.Line = line;

            List<ArticleTagViewModel> tags = new List<ArticleTagViewModel>();
            JsArray tagsValue = sourceValue["Tags"].As<JsArray>();
            for (int i = 0; i < tagsValue.length; i++)
            {
                JsObject tagValue = tagsValue[i].As<JsObject>();
                ArticleTagViewModel tag;
                if (Converts.Try(tagValue, out tag))
                    tags.Add(tag);
            }
            targetValue.Tags = tags;

            return true;
        }
    }
}

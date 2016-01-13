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
    public class ArticleLineEditViewModelConverter : ConverterBase<JsObject, ArticleLineEditViewModel>
    {
        public override bool TryConvert(JsObject sourceValue, out ArticleLineEditViewModel targetValue)
        {
            targetValue = new ArticleLineEditViewModel();
            targetValue.Key = sourceValue["Key"].As<int>();
            targetValue.Name = sourceValue["Name"].As<string>();
            targetValue.UrlPart = sourceValue["UrlPart"].As<string>();

            int[] keys = sourceValue["AvailableTagKeys"].As<int[]>();
            if (keys == null)
                targetValue.AvailableTagKeys = new List<int>();
            else
                targetValue.AvailableTagKeys = new List<int>(sourceValue["AvailableTagKeys"].As<int[]>());

            return true;
        }
    }
}

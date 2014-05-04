using Neptuo.ComponentModel.Converters;
using Neptuo.PresentationModels;
using SharpKit.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine
{
    public class ModelValueGetterListResultConverter : ConverterBase<JsObject, ModelValueGetterListResult>
    {
        public override bool TryConvert(JsObject sourceValue, out ModelValueGetterListResult targetValue)
        {
            int totalCount = sourceValue["TotalCount"].As<int>();
            JsObject data = sourceValue["Data"].As<JsObject>();

            targetValue = new ModelValueGetterListResult(GetModelValueGetters(data), totalCount);
            return true;
        }

        private IEnumerable<IModelValueGetter> GetModelValueGetters(JsObject sourceValue)
        {
            List<IModelValueGetter> data = new List<IModelValueGetter>();

            JsArray array = sourceValue.As<JsArray>();
            for (int i = 0; i < array.length; i++)
            {
                JsObject item = array[i].As<JsObject>();
                data.Add(new ModelValueGetterListResult.ModelValueGetter(item));
            }

            return data;

        }
    }
}

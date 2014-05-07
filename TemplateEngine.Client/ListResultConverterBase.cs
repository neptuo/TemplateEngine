using Neptuo.ComponentModel.Converters;
using Neptuo.TemplateEngine.Templates.DataSources;
using SharpKit.JavaScript;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine
{
    public abstract class ListResultConverterBase<TListResult, TItem> : ConverterBase<JsObject, TListResult>
        where TListResult : ListResult
    {
        public override bool TryConvert(JsObject sourceValue, out TListResult targetValue)
        {
            int totalCount = sourceValue["TotalCount"].As<int>();
            JsArray data = sourceValue["Data"].As<JsArray>();

            List<TItem> result = new List<TItem>();
            for (int i = 0; i < data.length; i++)
            {
                TItem item;
                if (TryConvertItem(data[i].As<JsObject>(), out item))
                    result.Add(item);

            }

            targetValue = CreateResult(result, totalCount);
            return true;
        }

        protected abstract bool TryConvertItem(JsObject sourceValue, out TItem item);

        protected abstract TListResult CreateResult(IEnumerable data, int totalCount);
    }
}

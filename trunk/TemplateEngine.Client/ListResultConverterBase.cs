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
    /// <summary>
    /// Base implmentation of <see cref="ConverterBase"/> for list result <see cref="ListResult"/> and JSON object.
    /// </summary>
    /// <typeparam name="TListResult">Type of <see cref="ListResult"/> descendant.</typeparam>
    /// <typeparam name="TItem">Type of list item.</typeparam>
    public abstract class ListResultConverterBase<TListResult, TItem> : ConverterBase<JsObject, TListResult>
        where TListResult : ListResult
    {
        /// <summary>
        /// Loads TotalCount and Data from JSON and calls <see cref="TryConvertItem"/> for every single Data item.
        /// </summary>
        /// <param name="sourceValue">JSON object.</param>
        /// <param name="targetValue">Target list result.</param>
        /// <returns>True if succeeds.</returns>
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

        /// <summary>
        /// Converts single item from <paramref name="sourceValue"/>.
        /// </summary>
        /// <param name="sourceValue">JSON item object.</param>
        /// <param name="item">Target item instance.</param>
        /// <returns>True if succeeds.</returns>
        protected abstract bool TryConvertItem(JsObject sourceValue, out TItem item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        protected abstract TListResult CreateResult(IEnumerable data, int totalCount);
    }
}

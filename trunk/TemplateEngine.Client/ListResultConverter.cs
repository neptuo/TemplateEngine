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
    public class ListResultConverter : ListResultConverterBase<ListResult, JsObject>
    {
        protected override bool TryConvertItem(JsObject sourceValue, out JsObject item)
        {
            item = sourceValue;
            return true;
        }

        protected override ListResult CreateResult(IEnumerable data, int totalCount)
        {
            return new ListResult(data, totalCount);
        }
    }
}

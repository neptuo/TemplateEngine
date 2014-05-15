using Neptuo.ComponentModel.Converters;
using SharpKit.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine
{
    public class JsObjectToJsObjectConverter : ConverterBase<JsObject, JsObject>
    {
        public override bool TryConvert(JsObject sourceValue, out JsObject targetValue)
        {
            targetValue = sourceValue;
            return true;
        }
    }
}

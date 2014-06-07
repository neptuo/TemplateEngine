using SharpKit.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates
{
    public class ClientBindingManager : BindingManagerBase
    {
        protected override bool TryGetValueInternal(string[] expression, int expressionIndex, object source, out object value)
        {
            if(expression.Length == expressionIndex)
            {
                value = source;
                return true;
            }

            JsObject sourceObject = source.As<JsObject>();
            if (sourceObject == null)
            {
                value = null;
                return true;
            }

            if (sourceObject["source"] != JsContext.undefined)
                sourceObject = sourceObject["source"].As<JsObject>();

            if (sourceObject[expression[expressionIndex]] == JsContext.undefined)
                return base.TryGetValueInternal(expression, expressionIndex, source, out value);

            sourceObject = sourceObject[expression[expressionIndex]].As<JsObject>();
            return TryGetValueInternal(expression, expressionIndex + 1, sourceObject, out value);
        }
    }
}

using SharpKit.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine
{
    public class JsObjectBuilder
    {
        private JsObject data = new JsObject();

        public static JsObjectBuilder New(string key = null, object value = null)
        {
            JsObjectBuilder result = new JsObjectBuilder();
            if (key != null)
                result.Set(key, value);
            
            return result;
        }

        public JsObjectBuilder Set(string key, object value)
        {
            data[key] = value;
            return this;
        }

        public JsObject ToJsObject()
        {
            return data;
        }
    }
}

using Neptuo.TemplateEngine.Routing;
using SharpKit.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public static class JsArrayExtensions
    {
        public static RouteParamDictionary ToRouteParams(this JsArray data)
        {
            RouteParamDictionary result = new RouteParamDictionary();
            if (data != null)
            {
                for (int i = 0; i < data.length; i++)
                {
                    string key = data[i].As<JsObject>()["name"].As<string>();
                    string value = data[i].As<JsObject>()["value"].As<string>();

                    string currentValue;
                    if (result.TryGetValue(key, out currentValue))
                        result[key] = currentValue + "," + value;
                    else
                        result.Add(key, value);
                }
            }

            return result;
        }
    }
}

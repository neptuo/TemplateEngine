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
                    result.Add(data[i].As<JsObject>()["name"].As<string>(), data[i].As<JsObject>()["value"].As<string>());
            }

            return result;
        }
    }
}

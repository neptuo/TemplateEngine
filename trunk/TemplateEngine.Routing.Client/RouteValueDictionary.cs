using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Routing
{
    public class RouteValueDictionary : Dictionary<string, string>
    {
        public static RouteValueDictionary FromUrl(string url)
        {
            Guard.NotNull(url, "url");

            int index = url.IndexOf('?');
            if (index > 0)
            {
                string queryString = url.Substring(index);
                return FromQueryString(queryString);
            }

            return new RouteValueDictionary();
        }

        public static RouteValueDictionary FromQueryString(string queryString)
        {
            RouteValueDictionary result = new RouteValueDictionary();
            if (String.IsNullOrEmpty(queryString))
                return result;

            if (queryString.StartsWith("?"))
                queryString = queryString.Substring(1);

            string[] keyValues = queryString.Split('&');
            foreach (string keyValue in keyValues)
            {
                string[] param = keyValue.Split('=');
                if (param.Length == 2)
                    result[param[0]] = param[1];
                else
                    result[param[0]] = null;
            }

            return result;
        }
    }
}

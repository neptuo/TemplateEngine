using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Routing
{
    public class RouteParamDictionary : Dictionary<string, string>
    {
        public RouteParamDictionary AddItem(string key, string value)
        {
            Add(key, value);
            return this;
        }

        #region Parsing from url and query string

        public static RouteParamDictionary FromUrl(string url)
        {
            Guard.NotNull(url, "url");

            int index = url.IndexOf('?');
            if (index > 0)
            {
                string queryString = url.Substring(index);
                return FromQueryString(queryString);
            }

            return new RouteParamDictionary();
        }

        public static RouteParamDictionary FromQueryString(string queryString)
        {
            RouteParamDictionary result = new RouteParamDictionary();
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

        #endregion
    }
}

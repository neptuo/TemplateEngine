using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Routing
{
    public class RequestContext
    {
        public string Url { get; protected set; }
        public RouteParamDictionary QueryString { get; protected set; }
        public RouteParamDictionary Form { get; protected set; }
        public RouteValueDictionary CustomValues { get; protected set; }

        public RequestContext(string url, RouteParamDictionary form, RouteValueDictionary customValues = null)
        {
            Guard.NotNullOrEmpty(url, "url");
            Guard.NotNull(form, "form");
            Url = RemoveQueryString(url);
            Form = form;
            QueryString = RouteParamDictionary.FromUrl(url);
            CustomValues = customValues ?? new RouteValueDictionary();
        }

        public static string RemoveQueryString(string url)
        {
            Guard.NotNullOrEmpty(url, "url");

            int index = url.IndexOf('?');
            if (index > 0)
                return url.Substring(0, index);

            return url;
        }
    }
}

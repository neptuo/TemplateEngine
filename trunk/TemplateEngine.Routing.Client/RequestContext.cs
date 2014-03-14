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
        public RouteValueDictionary QueryString { get; protected set; }
        public RouteValueDictionary Form { get; protected set; }

        public RequestContext(string url, RouteValueDictionary form)
        {
            Guard.NotNullOrEmpty(url, "url");
            Guard.NotNull(form, "form");
            Url = url;
            Form = form;
            QueryString = RouteValueDictionary.FromUrl(url);
        }
    }
}

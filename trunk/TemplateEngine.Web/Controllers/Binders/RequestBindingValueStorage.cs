using Neptuo.PresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Web.Controllers.Binders
{
    public class RequestBindingValueStorage : IBindingModelValueStorage
    {
        protected HttpRequestBase HttpRequest { get; private set; }

        public RequestBindingValueStorage(HttpRequestBase httpRequest)
        {
            HttpRequest = httpRequest;
        }

        public string GetValue(string identifier)
        {
            return HttpRequest.Params[identifier];
        }
    }
}

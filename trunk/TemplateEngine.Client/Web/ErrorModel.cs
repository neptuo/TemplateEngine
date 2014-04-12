using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class ErrorModel
    {
        public int StatusCode { get; private set; }
        public string StatusText { get; private set; }
        public string ResponseText { get; private set; }

        public ErrorModel(int statusCode, string statusText, string responseText)
        {
            StatusCode = statusCode;
            StatusText = statusText;
            ResponseText = responseText;
        }
    }
}

using SharpKit.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class FormRequestContext
    {
        public string[] ToUpdate { get; private set; }
        public JsArray Parameters { get; private set; }
        public string FormUrl { get; private set; }

        public FormRequestContext(string[] toUpdate, JsArray parameters, string formUrl)
        {
            ToUpdate = toUpdate;
            Parameters = parameters;
            FormUrl = formUrl;
        }
    }
}

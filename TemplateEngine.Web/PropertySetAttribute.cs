using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertySetAttribute : Attribute
    {
        public bool AllowFromRequest { get; set; }
        public string RequestKey { get; set; }

        public PropertySetAttribute(bool allowFromRequest, string requestKey = null)
        {
            AllowFromRequest = allowFromRequest;
            RequestKey = requestKey;
        }
    }
}

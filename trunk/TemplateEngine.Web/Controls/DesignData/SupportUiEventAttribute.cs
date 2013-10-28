using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls.DesignData
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SupportUiEventAttribute : Attribute
    {
        public IEnumerable<string> Events { get; set; }

        public SupportUiEventAttribute(params string[] events)
        {
            Events = events;
        }
    }
}

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
        public string Event { get; set; }
        public Type Handler { get; set; }

        public SupportUiEventAttribute(string eventName, Type handler)
        {
            Event = eventName;
            Handler = handler;
        }
    }
}

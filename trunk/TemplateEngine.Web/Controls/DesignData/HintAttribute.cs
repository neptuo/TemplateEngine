using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls.DesignData
{
    [AttributeUsage(AttributeTargets.All)]
    public class HintAttribute : Attribute
    {
        public string Text { get; private set; }

        public HintAttribute(string text)
        {
            Text = text;
        }
    }
}

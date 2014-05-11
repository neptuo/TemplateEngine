using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Default template path.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class DefaultTemplateAttribute : Attribute
    {
        public string Path { get; set; }

        public DefaultTemplateAttribute(string path)
        {
            Path = path;
        }
    }
}

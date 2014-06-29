using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.FluentConsole.Bootstrap
{
    /// <summary>
    /// Defines runnable component.
    /// Class must also implement <see cref="IRunnable"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ComponentAttribute : Attribute
    {
        /// <summary>
        /// Component name.
        /// </summary>
        public string Name { get; private set; }

        public ComponentAttribute(string name)
        {
            Guard.NotNull(name, "name");
            Name = name;
        }
    }
}

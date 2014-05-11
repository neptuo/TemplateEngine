using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates
{
    /// <summary>
    /// Creates instance of views.
    /// </summary>
    public interface IViewActivator
    {
        /// <summary>
        /// Creates instance of view on <paramref name="path"/>.
        /// </summary>
        BaseGeneratedView CreateView(string path);
    }
}

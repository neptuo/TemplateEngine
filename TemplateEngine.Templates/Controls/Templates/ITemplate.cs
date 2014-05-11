using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Describes template that can be repeateably evaluated.
    /// </summary>
    public interface ITemplate : IDisposable
    {
        /// <summary>
        /// Creates instance of template.
        /// </summary>
        ITemplateContent CreateInstance();
    }
}

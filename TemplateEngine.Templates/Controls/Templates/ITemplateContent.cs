using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Single renderable instance of template.
    /// </summary>
    public interface ITemplateContent : IControl, IDisposable
    { }
}

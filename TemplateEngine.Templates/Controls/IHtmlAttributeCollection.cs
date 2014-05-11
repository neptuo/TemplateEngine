using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Has <see cref="HtmlAttributeCollection"/>.
    /// </summary>
    public interface IHtmlAttributeCollection
    {
        HtmlAttributeCollection Attributes { get; }
    }
}

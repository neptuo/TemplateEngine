using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates
{
    /// <summary>
    /// Extended html writer.
    /// </summary>
    public interface IExtendedHtmlWriter : IHtmlWriter
    {
        /// <summary>
        /// Writes attribute on next used html tag.
        /// </summary>
        /// <param name="name">Attribute name.</param>
        /// <param name="value">Attribute value.</param>
        /// <returns>This (fluently).</returns>
        IExtendedHtmlWriter AttributeOnNextTag(string name, string value);
    }
}

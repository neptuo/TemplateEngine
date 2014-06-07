using Neptuo.Templates;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Describes paging control for <see cref="ListViewControl"/>.
    /// </summary>
    public interface IPaginationControl : IControl
    {
        /// <summary>
        /// Page size.
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        /// Page index.
        /// </summary>
        int PageIndex { get; set; }

        /// <summary>
        /// Total count.
        /// </summary>
        int TotalCount { get; set; }
    }
}

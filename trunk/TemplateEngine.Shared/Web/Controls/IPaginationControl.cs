using Neptuo.Templates;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public interface IPaginationControl : IControl
    {
        int PageSize { get; set; }
        int PageIndex { get; set; }
        int TotalCount { get; set; }
    }
}

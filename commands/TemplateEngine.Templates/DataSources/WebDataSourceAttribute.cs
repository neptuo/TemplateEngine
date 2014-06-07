using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.DataSources
{
    /// <summary>
    /// Marker attribute to mark data source as accessible through web.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class WebDataSourceAttribute : Attribute
    { }
}

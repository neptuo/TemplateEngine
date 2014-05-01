using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public interface ITemplateConfiguration
    {
        /// <summary>
        /// Gets current root app path.
        /// </summary>
        /// <example>
        /// /App/ThisApp
        /// </example>
        string ApplicationPath { get; }

        /// <summary>
        /// Name of default region to update.
        /// </summary>
        string[] DefaultToUpdate { get; }

        /// <summary>
        /// Url suffix for template pages.
        /// </summary>
        string TemplateUrlSuffix { get; }
    }
}

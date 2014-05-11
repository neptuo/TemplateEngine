using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Providers
{
    /// <summary>
    /// Formats template url.
    /// </summary>
    public interface ITemplateUrlFormatter
    {
        /// <summary>
        /// Url part in form of ~/Accounts/UserList and returns ~/Accounts/UserList.html if .html is current suffix.
        /// </summary>
        /// <param name="urlPart">Url part.</param>
        /// <returns>Formated template url.</returns>
        string FormatUrl(string urlPart);
    }
}

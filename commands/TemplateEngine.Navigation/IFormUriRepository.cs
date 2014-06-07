using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Navigation
{
    /// <summary>
    /// Repository for registrations.
    /// </summary>
    public interface IFormUriRepository
    {
        /// <summary>
        /// Tries to find regstration for <paramref name="identifier"/>.
        /// </summary>
        bool TryGet(string identifier, out FormUri formUri);

        /// <summary>
        /// Enumerates all registered forms.
        /// </summary>
        IEnumerable<FormUri> EnumerateForms();
    }
}

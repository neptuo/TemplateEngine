using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Navigation
{
    /// <summary>
    /// Enables to navigate to forms.
    /// </summary>
    public interface INavigator
    {
        /// <summary>
        /// Navigates to <paramref name="formUri"/>.
        /// </summary>
        void Open(FormUri formUri);

        /// <summary>
        /// Creates navigation object, <see cref="INavigateTo"/>, for <paramref name="formUri"/>.
        /// </summary>
        INavigateTo NavigateTo(FormUri formUri);
    }
}

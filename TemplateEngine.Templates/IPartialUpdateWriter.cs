using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates
{
    /// <summary>
    /// Registers control as region in partial rendering.
    /// </summary>
    public interface IPartialUpdateWriter
    {
        /// <summary>
        /// Registers <paramref name="control"/> as region renderer for region <paramref name="partialView"/>.
        /// </summary>
        /// <param name="partialView">Name of region.</param>
        /// <param name="control">Control, to region <paramref name="partialView"/>.</param>
        void Update(string partialView, IControl control);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    /// <summary>
    /// View renderer.
    /// </summary>
    public interface IAsyncViewRenderer
    {
        /// <summary>
        /// Fired when render is completed.
        /// </summary>
        event Action OnCompleted;

        /// <summary>
        /// Invkes render.
        /// </summary>
        void Render();
    }
}

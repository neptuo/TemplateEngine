using Neptuo.TemplateEngine.Controllers;
using Neptuo.TemplateEngine.Navigation;
using Neptuo.TemplateEngine.Providers;
using Neptuo.TemplateEngine.Routing;
using Neptuo.TemplateEngine.Templates;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public interface IApplication : ITemplateConfiguration, IVirtualUrlProvider, ICurrentUrlProvider
    {
        /// <summary>
        /// Whether is application in debug mode.
        /// </summary>
        bool IsDebug { get; }

        /// <summary>
        /// Provides access to application history state.
        /// </summary>
        IHistoryState HistoryState { get; }

        /// <summary>
        /// Provides access to whole user interface.
        /// </summary>
        IMainView MainView { get; }

        /// <summary>
        /// Root dependecy container.
        /// </summary>
        IDependencyContainer DependencyContainer { get; }

        /// <summary>
        /// Router.
        /// </summary>
        IRouter Router { get; }

        /// <summary>
        /// Registry for controllers.
        /// </summary>
        IAsyncControllerRegistry ControllerRegistry { get; }

        /// <summary>
        /// Tries to find and invoke controller.
        /// </summary>
        /// <param name="parameters">Form request context.</param>
        void InvokeController(FormRequestContext context);
    }
}

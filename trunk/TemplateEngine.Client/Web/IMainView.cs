using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    /// <summary>
    /// Represents whole user interface.
    /// </summary>
    public interface IMainView
    {
        /// <summary>
        /// Invoked when user clicks a link.
        /// </summary>
        event Action<string, string[]> OnLinkClick;

        /// <summary>
        /// Invoked when user posts a form.
        /// </summary>
        event Action<FormRequestContext> OnPostFormSubmit;
        
        /// <summary>
        /// Invoked when user submits GET form.
        /// </summary>
        event Action<string, string[]> OnGetFormSubmit;

        /// <summary>
        /// Renders user inteface with <paramref name="viewPath"/> and updates <paramref name="toUpdate"/> parts of view.
        /// Uses <paramref name="dependencyContainer"/> as dependencyContainer for rendering view.
        /// </summary>
        /// <param name="viewPath">New view.</param>
        /// <param name="toUpdate">Parts of user interface to update.</param>
        /// <param name="dependencyContainer">Depdency container used to render view.</param>
        void RenderView(string viewPath, string[] toUpdate, IDependencyContainer dependencyContainer);

        /// <summary>
        /// Updates content of element with <paramref name="partialGuid"/> with content from <paramref name="content"/>.
        /// </summary>
        /// <param name="partialGuid">Guid of element to update.</param>
        /// <param name="content">New content for element with <paramref name="partialGuid"/>.</param>
        void UpdateView(string partialGuid, TextWriter content);

        /// <summary>
        /// Writes placeholder for future partial update.
        /// </summary>
        /// <param name="writer">Html writer.</param>
        /// <param name="partialGuid">Guid for the element.</param>
        void WritePlaceholder(IHtmlWriter writer, string partialGuid);
    }
}

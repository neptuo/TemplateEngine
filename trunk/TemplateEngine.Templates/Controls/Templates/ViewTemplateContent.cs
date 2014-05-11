using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Implementation of <see cref="ITemplateContent"/> operation on separated view.
    /// </summary>
    public class ViewTemplateContent : ITemplateContent
    {
        public BaseGeneratedView View { get; private set; }

        public ViewTemplateContent(BaseGeneratedView view)
        {
            View = view;
        }

        public void OnInit()
        {
            View.Init();
        }

        public void Render(IHtmlWriter writer)
        {
            View.Render(writer);
        }

        public void Dispose()
        {
            View.Dispose();
        }
    }
}

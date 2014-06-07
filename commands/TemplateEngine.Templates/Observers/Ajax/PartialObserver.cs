using Neptuo.Templates;
using Neptuo.Templates.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Observers
{
    /// <summary>
    /// Sets region to update on current element submit.
    /// </summary>
    public class PartialObserver : IObserver
    {
        public string Update { get; set; }

        public void OnInit(ObserverEventArgs e)
        { }

        public void Render(ObserverEventArgs e, IHtmlWriter writer)
        {
            IExtendedHtmlWriter extendedWriter = writer as IExtendedHtmlWriter;
            if (extendedWriter != null)
                extendedWriter.AttributeOnNextTag("data-toupdate", Update);
        }
    }
}

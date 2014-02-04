using Neptuo.Templates;
using Neptuo.Templates.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Observers
{
    public class AjaxPartialObserver : IObserver
    {
        private IPartialUpdateWriter partialWriter;

        public string Partial { get; set; }

        public AjaxPartialObserver(IPartialUpdateWriter partialWriter)
        {
            Guard.NotNull(partialWriter, "partialWriter");

            this.partialWriter = partialWriter;
        }

        public void OnInit(ObserverEventArgs e)
        { }

        public void Render(ObserverEventArgs e, IHtmlWriter writer)
        {
            partialWriter.Update(Partial, e.Target);

            IExtendedHtmlWriter extendedWriter = writer as IExtendedHtmlWriter;
            if (extendedWriter != null)
                extendedWriter.AttributeOnNextTag("data-update", Partial);
        }
    }
}

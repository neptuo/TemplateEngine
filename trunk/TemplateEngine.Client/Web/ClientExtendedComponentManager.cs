using Neptuo.Templates;
using Neptuo.Templates.Controls;
using SharpKit.jQuery;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class ClientExtendedComponentManager : ExtendedComponentManager
    {
        private string[] partialsToUpdate;

        public ClientExtendedComponentManager(string[] partialsToUpdate)
        {
            Guard.NotNull(partialsToUpdate, "partialsToUpdate");
            this.partialsToUpdate = partialsToUpdate;
        }

        protected override void DoRenderControl(IControl control, IHtmlWriter writer)
        {
            string partialView;
            if (PartialUpdates.TryGetValue(control, out partialView) && partialsToUpdate.Contains(partialView))
            {
                StringWriter stringWriter = new StringWriter();
                ExtendedHtmlTextWriter extendedWriter = new ExtendedHtmlTextWriter(stringWriter);

                base.DoRenderControl(control, extendedWriter);

                jQuery target = new jQuery("[data-update=" + partialView + "]");
                target.replaceWith(stringWriter.ToString());
                return;
            }

            base.DoRenderControl(control, writer);
        }
    }
}

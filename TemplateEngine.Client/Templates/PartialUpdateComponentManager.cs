using Neptuo.Templates;
using Neptuo.Templates.Controls;
using SharpKit.jQuery;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates
{
    public class PartialUpdateComponentManager : ComponentManager, IPartialUpdateWriter
    {
        private string[] partialsToUpdate;
        private Dictionary<IControl, string> partialUpdates;

        public PartialUpdateComponentManager(string[] partialsToUpdate)
        {
            Guard.NotNull(partialsToUpdate, "partialsToUpdate");
            this.partialsToUpdate = partialsToUpdate;
            this.partialUpdates = new Dictionary<IControl, string>();
        }

        protected override void DoRenderControl(IControl control, IHtmlWriter writer)
        {
            string partialView;
            if (partialUpdates.TryGetValue(control, out partialView) && partialsToUpdate.Contains(partialView))
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

        public void Update(string partialView, IControl control)
        {
            partialUpdates[control] = partialView;
        }
    }
}

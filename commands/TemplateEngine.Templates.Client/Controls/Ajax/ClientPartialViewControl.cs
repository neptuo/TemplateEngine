using Neptuo.TemplateEngine.Web;
using Neptuo.Templates;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    public class ClientPartialViewControl : HtmlContentControlBase
    {
        protected IPartialUpdateWriter UpdateWriter { get; private set; }
        public string Partial { get; set; }

        public ClientPartialViewControl(IComponentManager componentManager, IPartialUpdateWriter updateWriter)
            : base(componentManager, "div")
        {
            UpdateWriter = updateWriter;
        }

        public override void OnInit()
        {
            Guard.NotNull(Partial, "Partial");

            base.OnInit();
            UpdateWriter.Update(Partial, this);
            Attributes.Add("data-update", Partial);
        }
    }
}

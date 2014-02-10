using Neptuo.Templates;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class ExtendedComponentManager : ComponentManager, IPartialUpdateWriter
    {
        protected Dictionary<IControl, string> PartialUpdates { get; private set; }

        public ExtendedComponentManager()
        {
            PartialUpdates = new Dictionary<IControl, string>();
        }

        public void Update(string partialView, IControl control)
        {
            PartialUpdates[control] = partialView;
        }
    }
}

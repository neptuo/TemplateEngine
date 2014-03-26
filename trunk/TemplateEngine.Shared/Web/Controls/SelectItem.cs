using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class SelectItem
    {
        public object Model { get; private set; }
        public bool IsSelected { get; set; }

        public SelectItem(object model)
        {
            Guard.NotNull(model, "model");
            Model = model;
        }
    }
}

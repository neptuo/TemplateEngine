using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Model describing state of item in <see cref="SelectControl"/>.
    /// </summary>
    public class SelectItem
    {
        /// <summary>
        /// Item model.
        /// </summary>
        public object Model { get; private set; }
        
        /// <summary>
        /// Is model in selected values?
        /// </summary>
        public bool IsSelected { get; set; }

        public SelectItem(object model)
        {
            Guard.NotNull(model, "model");
            Model = model;
        }
    }
}

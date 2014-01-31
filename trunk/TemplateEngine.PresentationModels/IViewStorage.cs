using Neptuo.PresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.PresentationModels
{
    public interface IViewStorage
    {
        IFieldView this[string identifier] { get; set; }
    }
}

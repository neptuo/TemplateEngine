using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public interface IFormControl
    {
        string Name { get; set; }

        void HandleValue(string value);
    }
}

using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates
{
    public interface IPartialUpdateWriter
    {
        void Update(string partialView, IControl control);
    }
}

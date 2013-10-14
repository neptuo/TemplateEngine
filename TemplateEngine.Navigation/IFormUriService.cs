using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Navigation
{
    public interface IFormUriService
    {
        bool TryGet(string identifier, out FormUri formUri);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public interface IAsyncViewRenderer
    {
        event Action OnCompleted;
        void Render();
    }
}

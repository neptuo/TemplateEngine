using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public interface IMainView
    {
        event Action<string, string[]> OnLinkClick;
        event Action<FormRequestContext> OnPostFormSubmit;
        event Action<string, string[]> OnGetFormSubmit;

        void RenderView(string viewPath, string[] toUpdate, IDependencyContainer dependencyContainer);
        void UpdateView(string partialGuid, TextWriter content);
    }
}

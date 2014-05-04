using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.ViewBundles
{
    public interface IViewBundle
    {
        string Name { get; }

        void AddView(string viewPath);
        void AddScript(string scriptPath);

        IEnumerable<string> EnumerateViews();
        IEnumerable<string> EnumerateScripts();

        bool ContainsView(string viewPath);
        bool ContainsScript(string scriptPath);
    }
}

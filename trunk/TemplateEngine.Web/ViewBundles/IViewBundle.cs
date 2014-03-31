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

        void Add(string viewPath);
        IEnumerable<string> EnumerateViews();

        bool ContainsView(string viewPath);
    }
}

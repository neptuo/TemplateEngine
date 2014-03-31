using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.ViewBundles
{
    public interface IViewBundleCollection
    {
        void Add(IViewBundle bundle);
        bool TryGet(string name, out IViewBundle bundle);
    }
}

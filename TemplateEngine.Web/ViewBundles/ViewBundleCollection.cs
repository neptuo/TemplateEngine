using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.ViewBundles
{
    public class ViewBundleCollection : IViewBundleCollection
    {
        protected Dictionary<string, IViewBundle> Bundles { get; private set; }

        public ViewBundleCollection()
        {
            Bundles = new Dictionary<string, IViewBundle>();
        }

        public void Add(IViewBundle bundle)
        {
            Guard.NotNull(bundle, "bundle");
            Bundles[bundle.Name] = bundle;
        }

        public bool TryGet(string name, out IViewBundle bundle)
        {
            Guard.NotNullOrEmpty(name, "name");
            return Bundles.TryGetValue(name, out bundle);
        }
    }
}

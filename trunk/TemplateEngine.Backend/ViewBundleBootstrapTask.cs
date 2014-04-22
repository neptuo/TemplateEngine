using Neptuo.Bootstrap;
using Neptuo.TemplateEngine.Web.ViewBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Backend
{
    public class ViewBundleBootstrapTask : IBootstrapTask
    {
        private IViewBundleCollection bundles;

        public ViewBundleBootstrapTask()
        {
            bundles = ViewBundleTable.Bundles;
        }

        public void Initialize()
        {
            IViewBundle bundle = new ViewBundle("Default");
            bundle.Add("~/Views/Default.view");
            bundle.Add("~/Views/Shared/AdminLayout.view");
            bundle.Add("~/Views/Shared/SubHeader.view");
            bundles.Add(bundle);
        }
    }
}

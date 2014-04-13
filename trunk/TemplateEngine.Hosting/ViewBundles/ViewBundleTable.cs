using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.ViewBundles
{
    public class ViewBundleTable
    {
        private static object lockBundles = new object();
        private static IViewBundleCollection bundles;

        public static IViewBundleCollection Bundles
        {
            get
            {
                if (bundles == null)
                {
                    lock (lockBundles)
                    {
                        if (bundles == null)
                            bundles = new ViewBundleCollection();
                    }
                }
                return bundles;
            }
        }
    }
}

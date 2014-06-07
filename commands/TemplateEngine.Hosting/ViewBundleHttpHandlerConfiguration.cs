using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Hosting
{
    public class ViewBundleHttpHandlerConfiguration
    {
        public string ViewDirectory { get; set; }
        public string TempDirectory { get; set; }

        public ViewBundleHttpHandlerConfiguration(string viewDirectory, string tempDirectory)
        {
            ViewDirectory = viewDirectory;
            TempDirectory = tempDirectory;
        }
    }
}

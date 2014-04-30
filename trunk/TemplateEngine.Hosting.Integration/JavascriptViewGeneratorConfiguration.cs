using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Hosting.Integration
{
    public class JavascriptViewGeneratorConfiguration
    {
        public string ViewDirectory { get; set; }
        public string TempDirectory { get; set; }

        public JavascriptViewGeneratorConfiguration(string viewDirectory, string tempDirectory)
        {
            ViewDirectory = viewDirectory;
            TempDirectory = tempDirectory;
        }
    }
}

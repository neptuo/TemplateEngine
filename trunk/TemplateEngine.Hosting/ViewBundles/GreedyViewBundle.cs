using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.ViewBundles
{
    public class GreedyViewBundle : IViewBundle
    {
        public string Name { get; set; }

        public void AddView(string viewPath)
        { }

        public void AddScript(string scriptPath)
        { }

        public IEnumerable<string> EnumerateViews()
        {
            return Enumerable.Empty<string>();
        }

        public IEnumerable<string> EnumerateScripts()
        {
            return Enumerable.Empty<string>();
        }

        public bool ContainsView(string viewPath)
        {
            return true;
        }

        public bool ContainsScript(string scriptPath)
        {
            return true;
        }
    }
}

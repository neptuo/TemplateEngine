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

        public void Add(string viewPath)
        { }

        public IEnumerable<string> EnumerateViews()
        {
            return new List<string>();
        }

        public bool ContainsView(string viewPath)
        {
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.ViewBundles
{
    public class ViewBundle : IViewBundle
    {
        protected HashSet<string> Views { get; private set; }

        public string Name { get; private set; }

        public ViewBundle(string name)
        {
            Guard.NotNullOrEmpty(name, "name");
            Name = name;
            Views = new HashSet<string>();
        }

        public void Add(string viewPath)
        {
            Guard.NotNullOrEmpty(viewPath, "viewPath");
            Views.Add(viewPath);
        }

        public IEnumerable<string> EnumerateViews()
        {
            return Views;
        }

        public bool ContainsView(string viewPath)
        {
            Guard.NotNullOrEmpty(viewPath, "viewPath");
            return Views.Contains(viewPath);
        }
    }
}

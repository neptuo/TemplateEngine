using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.ViewBundles
{
    /// <summary>
    /// Actual implmentation of <see cref="IViewBundle"/>.
    /// </summary>
    public class ViewBundle : IViewBundle
    {
        protected HashSet<string> Views { get; private set; }
        protected HashSet<string> Scripts { get; private set; }

        public string Name { get; private set; }

        public ViewBundle(string name)
        {
            Guard.NotNullOrEmpty(name, "name");
            Name = name;
            Views = new HashSet<string>();
            Scripts = new HashSet<string>();
        }

        public void AddView(string viewPath)
        {
            Guard.NotNullOrEmpty(viewPath, "viewPath");
            Views.Add(viewPath);
        }

        public void AddScript(string scriptPath)
        {
            Guard.NotNullOrEmpty(scriptPath, "scriptPath");
            Scripts.Add(scriptPath);
        }

        public IEnumerable<string> EnumerateViews()
        {
            return Views;
        }

        public IEnumerable<string> EnumerateScripts()
        {
            return Scripts;
        }

        public bool ContainsView(string viewPath)
        {
            Guard.NotNullOrEmpty(viewPath, "viewPath");
            return Views.Contains(viewPath);
        }

        public bool ContainsScript(string scriptPath)
        {
            Guard.NotNullOrEmpty(scriptPath, "scriptPath");
            return Scripts.Contains(scriptPath);
        }
    }
}

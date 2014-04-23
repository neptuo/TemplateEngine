using Neptuo.TemplateEngine.Web;
using Neptuo.Templates;
using SharpKit.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates
{
    public class StaticViewActivator : IViewActivator, IViewLoadedChecker
    {
        private static Dictionary<string, Type> mappings = new Dictionary<string, Type>();

        public static void Add(string viewPath, Type viewType)
        {
            mappings[viewPath] = viewType;
        }

        private IDependencyProvider dependencyProvider;

        public StaticViewActivator(IDependencyProvider dependencyProvider)
        {
            this.dependencyProvider = dependencyProvider;
        }

        public BaseGeneratedView CreateView(string path)
        {
            Type viewType;
            if (mappings.TryGetValue(path, out viewType))
                return (BaseGeneratedView)dependencyProvider.Resolve(viewType);

            if (Application.Instance.IsDebug)
                HtmlContext.alert("View class not found! For view path: " + path);

            HtmlContext.location.reload();
            throw new NotSupportedException();
        }

        public bool IsViewLoaded(string viewPath)
        {
            return mappings.ContainsKey(viewPath);
        }
    }
}

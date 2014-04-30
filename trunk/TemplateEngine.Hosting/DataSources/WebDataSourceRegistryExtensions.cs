using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Neptuo.TemplateEngine.Templates.DataSources;

namespace Neptuo.TemplateEngine.Hosting.DataSources
{
    public static class WebDataSourceRegistryExtensions
    {
        public static IWebDataSourceRegistry AddFromAssembly(this IWebDataSourceRegistry registry, Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                WebDataSourceAttribute attribute = type.GetCustomAttribute<WebDataSourceAttribute>();
                if (attribute != null)
                    registry.Add(type.Name, type);
            }

            return registry;
        }
    }
}

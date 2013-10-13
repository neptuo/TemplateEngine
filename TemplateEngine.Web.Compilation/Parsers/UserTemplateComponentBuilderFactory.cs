using Neptuo.Templates.Compilation.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Compilation.Parsers
{
    public class UserTemplateComponentBuilderFactory : IComponentBuilderFactory
    {
        public string TemplatePath { get; set; }

        public UserTemplateComponentBuilderFactory(string templatePath)
        {
            if (templatePath == null)
                throw new ArgumentNullException("templatePath");

            TemplatePath = templatePath;
        }

        public IComponentBuilder CreateBuilder(string prefix, string tagName)
        {
            return new UserTemplateComponentBuilder(TemplatePath);
        }
    }
}

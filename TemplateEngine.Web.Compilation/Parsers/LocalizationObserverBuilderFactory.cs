using Neptuo.Templates.Compilation.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Compilation.Parsers
{
    public class LocalizationObserverBuilderFactory : IObserverBuilderFactory
    {
        public IObserverRegistration CreateBuilder(string prefix, string attributeName)
        {
            return new LocalizationObserverRegistration();
        }
    }
}

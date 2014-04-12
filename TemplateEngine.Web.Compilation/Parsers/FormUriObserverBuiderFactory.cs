using Neptuo.TemplateEngine.Navigation;
using Neptuo.Templates.Compilation.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Compilation.Parsers
{
    public class FormUriObserverBuiderFactory : IObserverBuilderFactory
    {
        public IObserverRegistration CreateBuilder(string prefix, string attributeName)
        {
            return new FuncObserverBuilderRegistration(() => new FormUriObserverBuider(FormUriService.Instance), ObserverBuilderScope.PerElement);
        }
    }
}

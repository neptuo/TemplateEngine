using Neptuo.TemplateEngine.Navigation;
using Neptuo.Templates.Compilation.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Compilation.Parsers
{
    public class FormUriObserverBuiderRegistration : IObserverRegistration
    {
        public IObserverBuilder CreateBuilder()
        {
            return new FormUriObserverBuider(FormUriService.Instance);
        }

        public ObserverBuilderScope Scope
        {
            get { return ObserverBuilderScope.PerElement; }
        }
    }
}

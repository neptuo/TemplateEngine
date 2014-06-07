using Neptuo.Templates.Compilation.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Compilation.Parsers
{
    public class FuncObserverBuilderRegistration<T> : IObserverRegistration
        where T : IObserverBuilder
    {
        public Func<T> Factory { get; private set; }
        public ObserverBuilderScope Scope { get; private set; }

        public FuncObserverBuilderRegistration(Func<T> factory, ObserverBuilderScope scope)
        {
            if (factory == null)
                throw new ArgumentNullException("factory");

            Factory = factory;
            Scope = scope;
        }

        public IObserverBuilder CreateBuilder()
        {
            return Factory();
        }
    }

    public class FuncObserverBuilderRegistration : FuncObserverBuilderRegistration<IObserverBuilder>
    {
        public FuncObserverBuilderRegistration(Func<IObserverBuilder> factory, ObserverBuilderScope scope)
            : base(factory, scope)
        { }
    }
}

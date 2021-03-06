﻿using Neptuo.Templates.Compilation.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Compilation.Parsers
{
    public class LocalizationObserverBuilderFactory : IObserverBuilderFactory
    {
        public IObserverRegistration CreateBuilder(string prefix, string attributeName)
        {
            return new FuncObserverBuilderRegistration(() => new LocalizationObserverBuilder(), ObserverBuilderScope.PerElement);
        }
    }
}

using Neptuo.PresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controllers.Binders
{
    public class BindingValueStorage : IBindingModelValueStorage
    {
        protected IParameterProvider ParameterProvider { get; private set; }

        public BindingValueStorage(IParameterProvider parameterProvider)
        {
            Guard.NotNull(parameterProvider, "parameterProvider");
            ParameterProvider = parameterProvider;
        }

        public string GetValue(string identifier)
        {
            Guard.NotNull(identifier, "identifier");

            object value;
            if(ParameterProvider.TryGet(identifier, out value))
                return (string)value;

            return null;
        }

        public bool TryGetValue(string identifier, out string targetValue)
        {
            Guard.NotNull(identifier, "identifier");

            object value;
            if (ParameterProvider.TryGet(identifier, out value))
            {
                targetValue = (string)value;
                return true;
            }

            targetValue = null;
            return false;
        }
    }
}

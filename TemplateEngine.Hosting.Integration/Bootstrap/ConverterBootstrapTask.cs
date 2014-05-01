using Neptuo.Bootstrap;
using Neptuo.ComponentModel.Converters;
using Neptuo.TemplateEngine.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Hosting.Integration.Bootstrap
{
    public class ConverterBootstrapTask : IBootstrapTask
    {
        private IConverterRepository converterRepository;

        public ConverterBootstrapTask()
        {
            converterRepository = Converts.Repository;
        }

        public void Initialize()
        {
            converterRepository.OnSearchConverter += OnSearchConverter;
        }

        private IConverter OnSearchConverter(Type sourceType, Type targetType)
        {
            if (targetType == typeof(JsonResponse))
                return new JsonConverter();

            return null;
        }
    }
}

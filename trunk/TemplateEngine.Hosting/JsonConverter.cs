using Neptuo.ComponentModel.Converters;
using Neptuo.TemplateEngine.Providers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Hosting.Integration
{
    public class JsonConverter : ConverterBase<object, JsonResponse>
    {
        public override bool TryConvert(object sourceValue, out JsonResponse targetValue)
        {
            targetValue = new JsonResponse(JsonConvert.SerializeObject(sourceValue));
            return true;
        }
    }
}

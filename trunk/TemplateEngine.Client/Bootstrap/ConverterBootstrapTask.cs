using Neptuo.Bootstrap;
using Neptuo.ComponentModel.Converters;
using Neptuo.TemplateEngine.Controllers;
using Neptuo.TemplateEngine.Providers;
using Neptuo.TemplateEngine.Web;
using SharpKit.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Bootstrap
{
    /// <summary>
    /// Registers converters.
    /// </summary>
    public class ConverterBootstrapTask : IBootstrapTask
    {
        private IConverterRepository repository;

        public ConverterBootstrapTask()
        {
            repository = Converts.Repository;
        }

        public void Initialize()
        {
            repository
                .Add(typeof(JsObject), typeof(PartialResponse), new PartialResponseConverter());
        }
    }
}

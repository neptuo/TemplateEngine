using Neptuo.Bootstrap;
using Neptuo.ComponentModel.Converters;
using Neptuo.TemplateEngine.Publishing.ViewModels;
using SharpKit.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.Bootstrap
{
    public class PublishingBootstrapTask : IBootstrapTask
    {
        private IConverterRepository converterRepository;

        public PublishingBootstrapTask()
        {
            converterRepository = Converts.Repository;
        }

        public void Initialize()
        {
            converterRepository
                .Add(typeof(JsObject), typeof(ArticleViewModel), new ArticleViewModelConverter());
        }
    }
}

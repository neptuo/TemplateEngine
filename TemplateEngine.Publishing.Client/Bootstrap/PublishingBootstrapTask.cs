﻿using Neptuo.Bootstrap;
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
                .Add(typeof(JsObject), typeof(ArticleViewModel), new ArticleViewModelConverter())
                .Add(typeof(JsObject), typeof(ArticleTagViewModel), new ArticleTagViewModelConverter())
                .Add(typeof(JsObject), typeof(ArticleLineViewModel), new ArticleLineViewModelConverter())

                .Add(typeof(JsObject), typeof(ArticleListResult), new ArticleListResultConverter())
                .Add(typeof(JsObject), typeof(ArticleTagListResult), new ArticleTagListResultConverter())
                .Add(typeof(JsObject), typeof(ArticleLineListResult), new ArticleLineListResultConverter())

                .Add(typeof(JsObject), typeof(ArticleEditViewModel), new ArticleEditViewModelConverter())
                .Add(typeof(JsObject), typeof(ArticleTagEditViewModel), new ArticleTagEditViewModelConverter())
                .Add(typeof(JsObject), typeof(ArticleLineEditViewModel), new ArticleLineEditViewModelConverter());
        }
    }
}

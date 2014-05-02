﻿using Neptuo.Data.Queries;
using Neptuo.TemplateEngine.Providers.ModelBinders;
using Neptuo.TemplateEngine.Publishing.Data.Queries;
using Neptuo.TemplateEngine.Publishing.ViewModels;
using Neptuo.TemplateEngine.Templates.DataSources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.Templates.DataSources
{
    public class ArticleLineDataSource : IListDataSource, IDataSource, IArticleLineDataSourceFilter
    {
        private IArticleLineQuery query;
        private IModelBinder modelBinder;

        public int? Key { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public ArticleLineDataSource(IArticleLineQuery query, IModelBinder modelBinder)
        {
            Guard.NotNull(query, "query");
            Guard.NotNull(modelBinder, "modelBinder");
            this.query = query;
            this.modelBinder = modelBinder;
        }

        protected void ApplyFilter()
        {
            if (Key != null)
                query.Filter.Key = IntSearch.Create(Key.Value);

            if (!String.IsNullOrEmpty(Name))
                query.Filter.Name = TextSearch.Contains(Name);

            if (!String.IsNullOrEmpty(Url))
                query.Filter.Url = TextSearch.Create(Url);

            query.OrderBy(l => l.Name);
        }

        public object GetItem()
        {
            ArticleLineViewModel viewModel = new ArticleLineViewModel();
            if (Key != null)
            {
                query.Filter.Key = IntSearch.Create(Key.Value);
                ArticleLine model = query.ResultSingle();
                viewModel = new ArticleLineViewModel(model.Key, model.Name, model.Url);
            }

            modelBinder.Bind(viewModel);
            return viewModel;
        }

        public IEnumerable GetData(int? pageIndex, int? pageSize)
        {
            ApplyFilter();

            List<ArticleLineViewModel> result = new List<ArticleLineViewModel>();
            foreach (ArticleLine line in query.EnumeratePageItems(pageIndex, pageSize))
                result.Add(new ArticleLineViewModel(line.Key, line.Name, line.Url));

            return result;  
        }

        public int GetTotalCount()
        {
            ApplyFilter();
            return query.Count();
        }
    }
}

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
    [WebDataSource]
    public class ArticleTagDataSource : IListDataSource, IDataSource, IArticleTagDataSourceFilter
    {
        private IArticleTagQuery query;
        private IModelBinder modelBinder;

        public IEnumerable<int> Key { get; set; }
        public string Name { get; set; }
        public string UrlPart { get; set; }

        public ArticleTagDataSource(IArticleTagQuery query, IModelBinder modelBinder)
        {
            Guard.NotNull(query, "query");
            Guard.NotNull(modelBinder, "modelBinder");
            this.query = query;
            this.modelBinder = modelBinder;
        }

        protected void ApplyFilter()
        {
            if (Key != null)
                query.Filter.Key = IntSearch.Create(Key);

            if (!String.IsNullOrEmpty(Name))
                query.Filter.Name = TextSearch.StartsWith(Name);

            if (!String.IsNullOrEmpty(UrlPart))
                query.Filter.Url = TextSearch.Create(UrlPart);

            query.OrderBy(t => t.Name);
        }

        public object GetItem()
        {
            ArticleTagEditViewModel viewModel = new ArticleTagEditViewModel();
            if (Key != null)
            {
                query.Filter.Key = IntSearch.Create(Key);
                ArticleTag model = query.ResultSingle();
                viewModel = new ArticleTagEditViewModel(model.Key, model.Name, model.Url);
            }

            modelBinder.Bind(viewModel);
            return viewModel;
        }

        public IEnumerable GetData(int? pageIndex, int? pageSize)
        {
            ApplyFilter();

            List<ArticleTagViewModel> result = new List<ArticleTagViewModel>();
            foreach (ArticleTag tag in query.EnumeratePageItems(pageIndex, pageSize))
                result.Add(new ArticleTagViewModel(tag.Key, tag.Name, tag.Url));

            return result;
        }

        public int GetTotalCount()
        {
            ApplyFilter();
            return query.Count();
        }
    }
}

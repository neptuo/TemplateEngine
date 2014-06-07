using Neptuo.Data.Queries;
using Neptuo.TemplateEngine.Controllers;
using Neptuo.TemplateEngine.Providers;
using Neptuo.TemplateEngine.Publishing.Controllers.Commands;
using Neptuo.TemplateEngine.Publishing.Data;
using Neptuo.TemplateEngine.Publishing.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.Controllers
{
    public class ArticleController : ControllerBase
    {
        private IArticleRepository repository;
        private IArticleLineRepository lineRepository;
        private IActivator<IArticleTagQuery> tagQueryFactory;

        public ArticleController(IArticleRepository repository, IArticleLineRepository lineRepository, IActivator<IArticleTagQuery> tagQueryFactory)
        {
            Guard.NotNull(repository, "repository");
            Guard.NotNull(lineRepository, "lineRepository");
            Guard.NotNull(tagQueryFactory, "tagQueryFactory");
            this.repository = repository;
            this.lineRepository = lineRepository;
            this.tagQueryFactory = tagQueryFactory;
        }

        [Transactional]
        [Validate("ArticleEdit")]
        [Action("Publishing/Article/Create")]
        public string Create(ArticleCreateCommand model)
        {
            ArticleLine line = lineRepository.Get(model.LineKey);
            if(line == null)
            {
                Messages.Add(null, String.Empty, "No such article line.", MessageType.Warn);
                return null;
            }

            repository.Insert(new Article
            {
                Title = model.Title,
                Content = model.Content,
                Url = model.UrlPart,
                Author = model.Author,
                Created = DateTime.Now,
                LastModified = DateTime.Now,
                IsVisible = model.IsVisible,
                Line = line,
                Tags = new List<ArticleTag>(GetSelectedTags(model.TagKeys))
            });

            return "Publishing.Article.Created";
        }
        
        [Transactional]
        [Validate("ArticleEdit")]
        [Action("Publishing/Article/Update")]
        public string Update(ArticleEditCommand model)
        {
            Article article = repository.Get(model.Key);
            if(article == null)
            {
                Messages.Add(null, String.Empty, "No such article.", MessageType.Warn);
                return null;
            }

            if (article.Title != model.Title)
                article.Title = model.Title;

            if (article.Content != model.Content)
                article.Content = model.Content;

            if (article.Url != model.UrlPart)
                article.Url = model.UrlPart;

            if (article.Author != model.Author)
                article.Author = model.Author;

            if (article.IsVisible != model.IsVisible)
                article.IsVisible = model.IsVisible;

            if (article.Line.Key != model.LineKey)
            {
                ArticleLine line = lineRepository.Get(model.LineKey);
                if (line == null)
                {
                    Messages.Add(null, String.Empty, "No such article line.", MessageType.Warn);
                    return null;
                }
                article.Line = line;
            }

            article.LastModified = DateTime.Now;

            article.Tags.Clear();
            foreach (ArticleTag tag in GetSelectedTags(model.TagKeys))
                article.Tags.Add(tag);

            repository.Update(article);

            return "Publishing.Article.Updated";
        }

        [Action("Publishing/Article/Delete")]
        public string Update(ArticleDeleteCommand model)
        {
            Article article = repository.Get(model.ArticleKey);
            if (article == null)
            {
                Messages.Add(null, String.Empty, "No such article.", MessageType.Warn);
                return null;
            }

            repository.Delete(article);
            Messages.Add(null, String.Empty, "Article line deleted.", MessageType.Info);

            return "Publishing.Article.Deleted";
        }

        private IEnumerable<ArticleTag> GetSelectedTags(IEnumerable<int> keys)
        {
            List<ArticleTag> result = new List<ArticleTag>();
            if (keys == null)
                return result;

            var query = tagQueryFactory.Create();
            query.Filter.Key = IntSearch.Create(keys);
            return query.EnumerateItems();
        }
    }
}

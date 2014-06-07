using Neptuo.Data;
using Neptuo.TemplateEngine.Controllers;
using Neptuo.TemplateEngine.Publishing.Controllers.Commands;
using Neptuo.TemplateEngine.Publishing.Data;
using Neptuo.TemplateEngine.Publishing.Data.Queries;
using Neptuo.TemplateEngine.Providers;
using Neptuo.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neptuo.Data.Queries;

namespace Neptuo.TemplateEngine.Publishing.Controllers
{
    public class ArticleLineController : ControllerBase
    {
        private IArticleLineRepository repository;
        private IActivator<IArticleLineQuery> queryFactory;
        private IActivator<IArticleTagQuery> tagQueryFactory;

        public ArticleLineController(IArticleLineRepository repository, IActivator<IArticleLineQuery> queryFactory, IActivator<IArticleTagQuery> tagQueryFactory)
        {
            Guard.NotNull(repository, "repository");
            Guard.NotNull(queryFactory, "queryFactory");
            Guard.NotNull(tagQueryFactory, "tagQueryFactory");
            this.repository = repository;
            this.queryFactory = queryFactory;
            this.tagQueryFactory = tagQueryFactory;
        }

        [Transactional]
        [Validate("ArticleLineEdit")]
        [Action("Publishing/ArticleLine/Create")]
        public string Create(ArticleLineCreateCommand model)
        {
            Guard.NotNull(model, "model");

            repository.Insert(new ArticleLine
            {
                Name = model.Name,
                Url = model.UrlPart,
                AvailableTags = new List<ArticleTag>(GetSelectedTags(model.AvailableTagKeys))
            });

            Messages.Add(null, String.Empty, "Article line created.", MessageType.Info);
            return "Publishing.ArticleLine.Created";
        }

        [Transactional]
        [Validate("ArticleLineEdit")]
        [Action("Publishing/ArticleLine/Update")]
        public string Update(ArticleLineEditCommand model)
        {
            Guard.NotNull(model, "model");

            ArticleLine line = repository.Get(model.Key);
            if (line == null)
            {
                Messages.Add(null, String.Empty, "No such article line.", MessageType.Warn);
                return null;
            }

            if (line.Name != model.Name)
                line.Name = model.Name;

            if (line.Url != model.UrlPart)
                line.Url = model.UrlPart;

            line.AvailableTags.Clear();
            foreach (ArticleTag tag in GetSelectedTags(model.AvailableTagKeys))
                line.AvailableTags.Add(tag);

            repository.Update(line);

            Messages.Add(null, String.Empty, "Article line update.", MessageType.Info);
            return "Publishing.ArticleLine.Updated";
        }

        [Action("Publishing/ArticleLine/Delete")]
        public string Delete(ArticleLineDeleteCommand model)
        {
            Guard.NotNull(model, "model");

            ArticleLine line = repository.Get(model.LineKey);
            if (line == null)
            {
                Messages.Add(null, String.Empty, "Article line not found.", MessageType.Warn);
                return null;
            }

            repository.Delete(line);

            Messages.Add(null, String.Empty, "Article line deleted.", MessageType.Info);
            return "Publishing.ArticleLine.Deleted";
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

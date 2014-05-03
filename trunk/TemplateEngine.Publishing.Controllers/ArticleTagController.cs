using Neptuo.Data;
using Neptuo.TemplateEngine.Controllers;
using Neptuo.TemplateEngine.Providers;
using Neptuo.TemplateEngine.Publishing.Controllers.Commands;
using Neptuo.TemplateEngine.Publishing.Data;
using Neptuo.TemplateEngine.Publishing.Data.Queries;
using Neptuo.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.Controllers
{
    public class ArticleTagController : ControllerBase
    {
        private IArticleTagRepository repository;
        private IActivator<IArticleTagQuery> queryFactory;

        public ArticleTagController(IArticleTagRepository repository, IActivator<IArticleTagQuery> queryFactory)
        {
            Guard.NotNull(repository, "repository");
            Guard.NotNull(queryFactory, "queryFactory");
            this.repository = repository;
            this.queryFactory = queryFactory;
        }

        [Transactional]
        [Validate("ArticleTagEdit")]
        [Action("Publishing/ArticleTag/Create")]
        public string Create(ArticleTagCreateCommand model)
        {
            Guard.NotNull(model, "model");

            repository.Insert(new ArticleTag
            {
                Name = model.Name,
                Url = model.UrlPart
            });

            Messages.Add(null, String.Empty, "Article tag created.", MessageType.Info);
            return "Publishing.ArticleTag.Created";
        }

        [Transactional]
        [Validate("ArticleTagEdit")]
        [Action("Publishing/ArticleTag/Update")]
        public string Update(ArticleTagEditCommand model)
        {
            Guard.NotNull(model, "model");

            ArticleTag tag = repository.Get(model.Key);
            if (tag == null)
            {
                Messages.Add(null, String.Empty, "No such article tag.", MessageType.Warn);
                return null;
            }

            tag.Name = model.Name;
            tag.Url = model.UrlPart;
            repository.Update(tag);

            Messages.Add(null, String.Empty, "Article tag updated.", MessageType.Info);
            return "Publishing.ArticleTag.Updated";
        }

        [Action("Publishing/ArticleTag/Delete")]
        public string Delete(ArticleTagDeleteCommand model)
        {
            Guard.NotNull(model, "model");

            ArticleTag tag = repository.Get(model.TagKey);
            if (tag == null)
            {
                Messages.Add(null, String.Empty, "Article tag not found.", MessageType.Warn);
                return null;
            }

            repository.Delete(tag);

            Messages.Add(null, String.Empty, "Article tag deleted.", MessageType.Info);
            return "Publishing.ArticleTag.Deleted";
        }
    }
}

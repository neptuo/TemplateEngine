using Neptuo.Data.Queries;
using Neptuo.Linq.Expressions;
using Neptuo.TemplateEngine.Publishing.Controllers.Commands;
using Neptuo.TemplateEngine.Publishing.Data.Queries;
using Neptuo.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.Controllers.Validation
{
    public class ArticleValidator : IValidator<ArticleCreateCommand>, IValidator<ArticleEditCommand>
    {
        private static readonly string titleKey = TypeHelper.PropertyName<ArticleCreateCommand, string>(c => c.Title);
        private static readonly string urlPartKey = TypeHelper.PropertyName<ArticleCreateCommand, string>(c => c.UrlPart);
        private static readonly string authorKey = TypeHelper.PropertyName<ArticleCreateCommand, string>(c => c.Author);
        private static readonly string lineKey = TypeHelper.PropertyName<ArticleCreateCommand, int>(c => c.LineKey);

        private IActivator<IArticleQuery> queryFactory;

        public ArticleValidator(IActivator<IArticleQuery> queryFactory)
        {
            Guard.NotNull(queryFactory, "queryFactory");
            this.queryFactory = queryFactory;
        }

        public IValidationResult Validate(ArticleCreateCommand model)
        {
            Guard.NotNull(model, "model");
            List<IValidationMessage> messages = new List<IValidationMessage>();
            ValidateTitle(null, model.Title, messages);
            ValidateUrl(null, model.UrlPart, messages);
            return new ValidationResultBase(!messages.Any(), messages);
        }

        public IValidationResult Validate(ArticleEditCommand model)
        {
            Guard.NotNull(model, "model");
            List<IValidationMessage> messages = new List<IValidationMessage>();
            ValidateTitle(model.Key, model.Title, messages);
            ValidateUrl(model.Key, model.UrlPart, messages);
            return new ValidationResultBase(!messages.Any(), messages);
        }

        private void ValidateTitle(int? key, string title, List<IValidationMessage> messages)
        {
            if (String.IsNullOrEmpty(title))
                messages.Add(new StringNullOrEmptyMessage(titleKey));
        }

        private void ValidateUrl(int? key, string url, List<IValidationMessage> messages)
        {
            if (String.IsNullOrEmpty(url))
                messages.Add(new StringNullOrEmptyMessage(urlPartKey));
            else if (IsUrlUsed(key, url))
                messages.Add(new TextValidationMessage(urlPartKey, "Url is already taken by another article!"));
        }

        private bool IsUrlUsed(int? key, string url)
        {
            var query = queryFactory.Create();
            query.Filter.Url = TextSearch.Create(url);

            IEnumerable<int> keys = query.EnumerateItems(u => u.Key);
            if (key == null)
                return keys.Any();

            return !keys.All(k => k == key.Value);
        }
    }
}

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
    public class ArticleLineValidator : IValidator<ArticleLineCreateCommand>, IValidator<ArticleLineEditCommand>
    {
        private static readonly string nameKey = TypeHelper.PropertyName<ArticleLineCreateCommand, string>(c => c.Name);

        private IActivator<IArticleLineQuery> queryFactory;

        public ArticleLineValidator(IActivator<IArticleLineQuery> queryFactory)
        {
            Guard.NotNull(queryFactory, "queryFactory");
            this.queryFactory = queryFactory;
        }

        public IValidationResult Validate(ArticleLineCreateCommand model)
        {
            Guard.NotNull(model, "model");
            List<IValidationMessage> messages = new List<IValidationMessage>();
            ValidateName(null, model.Name, messages);
            ValidateUrl(null, model.UrlPart, messages);
            return new ValidationResultBase(!messages.Any(), messages);
        }

        public IValidationResult Validate(ArticleLineEditCommand model)
        {
            Guard.NotNull(model, "model");
            List<IValidationMessage> messages = new List<IValidationMessage>();
            ValidateName(model.Key, model.Name, messages);
            ValidateUrl(model.Key, model.UrlPart, messages);
            return new ValidationResultBase(!messages.Any(), messages);
        }

        private void ValidateName(int? key, string name, List<IValidationMessage> messages)
        {
            if (String.IsNullOrEmpty(name))
                messages.Add(new StringNullOrEmptyMessage(nameKey));
            else if (IsNameUsed(key, name))
                messages.Add(new TextValidationMessage(nameKey, "Name is already taken by another line!"));
        }

        private void ValidateUrl(int? key, string url, List<IValidationMessage> messages)
        {
            if (String.IsNullOrEmpty(url))
                messages.Add(new StringNullOrEmptyMessage(nameKey));
            else if (IsNameUsed(key, url))
                messages.Add(new TextValidationMessage(nameKey, "Url is already taken by another line!"));
        }

        private bool IsNameUsed(int? key, string name)
        {
            var query = queryFactory.Create();
            query.Filter.Name = TextSearch.Create(name);

            IEnumerable<int> keys = query.EnumerateItems(u => u.Key);
            if (key == null)
                return keys.Any();

            return !keys.All(k => k == key.Value);
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

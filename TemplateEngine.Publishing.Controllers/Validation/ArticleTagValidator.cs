﻿using Neptuo.Data.Queries;
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
    public class ArticleTagValidator : IValidator<ArticleTagCreateCommand>, IValidator<ArticleTagEditCommand>
    {
        private static readonly string nameKey = TypeHelper.PropertyName<ArticleTagCreateCommand, string>(c => c.Name);
        private static readonly string urlPartKey = TypeHelper.PropertyName<ArticleTagCreateCommand, string>(c => c.UrlPart);

        private IActivator<IArticleTagQuery> queryFactory;

        public ArticleTagValidator(IActivator<IArticleTagQuery> queryFactory)
        {
            Guard.NotNull(queryFactory, "queryFactory");
            this.queryFactory = queryFactory;
        }

        public IValidationResult Validate(ArticleTagCreateCommand model)
        {
            Guard.NotNull(model, "model");
            List<IValidationMessage> messages = new List<IValidationMessage>();
            ValidateName(null, model.Name, messages);
            ValidateUrl(null, model.UrlPart, messages);
            return new ValidationResultBase(!messages.Any(), messages);
        }

        public IValidationResult Validate(ArticleTagEditCommand model)
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
                messages.Add(new TextValidationMessage(nameKey, "Name is already taken by another tag!"));
        }

        private void ValidateUrl(int? key, string url, List<IValidationMessage> messages)
        {
            if (String.IsNullOrEmpty(url))
                messages.Add(new StringNullOrEmptyMessage(urlPartKey));
            else if (IsUrlUsed(key, url))
                messages.Add(new TextValidationMessage(urlPartKey, "Url is already taken by another tag!"));
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

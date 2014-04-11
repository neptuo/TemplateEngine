﻿using Neptuo.Data.Entity.Queries;
using Neptuo.TemplateEngine.Accounts.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data.Entity.Queries
{
    public class EntityUserAccountQuery : EntityQuery<UserAccount, IUserAccountFilter>, IUserAccountQuery
    {
        public EntityUserAccountQuery(DataContext dbContext)
            : base(dbContext.UserAccounts)
        { }

        protected override Expression BuildWhereExpression(Expression parameter)
        {
            Expression target = null;

            if (Filter != null)
            {
                if (Filter.Key != null)
                    target = EntityQuerySearch.BuildIntSearch<UserAccount>(target, parameter, u => u.Key, Filter.Key);

                if (Filter.Username != null)
                    target = EntityQuerySearch.BuildTextSearch<UserAccount>(target, parameter, u => u.Username, Filter.Username);

                if (Filter.Password != null)
                    target = EntityQuerySearch.BuildTextSearch<UserAccount>(target, parameter, u => u.Password, Filter.Password);

                //TODO: Add IsEnabled;

                //if (Filter.RoleKey != null)
                //    Items.Where(u => u.Roles.Select(r => r.Key).Contains(Filter.RoleKey.Value));
                //    target = EntityQuerySearch.BuildTextSearch<UserAccountEntity>(target, parameter, u => u.Password, Filter.Password);
            }

            return target;
        }

        protected override IUserAccountFilter CreateFilter()
        {
            return new UserAccountFilter();
        }
    }
}
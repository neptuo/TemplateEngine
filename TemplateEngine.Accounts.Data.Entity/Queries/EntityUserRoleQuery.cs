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
    public class EntityUserRoleQuery : EntityQuery<UserRole, IUserRoleFilter>, IUserRoleQuery
    {
        public EntityUserRoleQuery(DataContext dbContext)
            : base(dbContext.UserRoles)
        { }

        protected override Expression BuildWhereExpression(ParameterExpression parameter)
        {
            Expression target = null;

            if (Filter != null)
            {
                if (Filter.Key != null)
                    target = EntityQuerySearch.BuildIntSearch<UserRole>(target, parameter, r => r.Key, Filter.Key);

                if (Filter.Name != null)
                    target = EntityQuerySearch.BuildTextSearch<UserRole>(target, parameter, r => r.Name, Filter.Name);

                if (Filter.Description != null)
                    target = EntityQuerySearch.BuildTextSearch<UserRole>(target, parameter, r => r.Description, Filter.Description);
            }

            return target;
        }

        protected override IUserRoleFilter CreateFilter()
        {
            return new UserRoleFilter();
        }
    }
}

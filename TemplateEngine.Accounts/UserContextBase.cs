﻿using Neptuo.TemplateEngine.Accounts.Data.Queries;
using Neptuo.TemplateEngine.Configuration;
using Neptuo.TemplateEngine.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class UserContextBase : IUserLogContext, IUserContext
    {
        private IApplicationConfiguration configuration;
        private IActivator<IResourcePermissionQuery> permissionQueryFactory;
        private IPermissionProvider permissionProvider;

        public virtual UserLog Log { get; protected set; }

        public IUserInfo User
        {
            get { return Log.User; }
        }

        public IPermissionProvider Permissions
        {
            get
            {
                if (permissionProvider == null)
                    permissionProvider = GetPermissionProvider();

                return permissionProvider;
            }
        }

        public virtual bool IsAuthenticated { get; protected set; }

        public virtual string AuthenticationToken { get; protected set; }

        public UserContextBase(IApplicationConfiguration configuration, UserLog log, IActivator<IResourcePermissionQuery> permissionQueryFactory, string authenticationToken = null)
        {
            Guard.NotNull(configuration, "configuration");
            Guard.NotNull(permissionQueryFactory, "permissionQueryFactory");
            Log = log;
            
            if (!String.IsNullOrEmpty(authenticationToken))
            {
                AuthenticationToken = authenticationToken;
                IsAuthenticated = true;
            }

            this.configuration = configuration;
            this.permissionQueryFactory = permissionQueryFactory;
        }

        protected virtual IPermissionProvider GetPermissionProvider()
        {
            List<int> roleKeys = new List<int> { GetAnonymousUserRoleKey() };
            if (IsAuthenticated)
                roleKeys.AddRange(Log.User.Roles.Select(r => r.Key));

            return new ResourcePermissionProvider(permissionQueryFactory, roleKeys);
        }

        protected virtual int GetAnonymousUserRoleKey()
        {
            return configuration.AnonymousRoleKey;
        }
    }
}

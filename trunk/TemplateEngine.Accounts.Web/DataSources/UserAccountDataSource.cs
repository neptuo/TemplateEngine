﻿using Neptuo.Data;
using Neptuo.PresentationModels.TypeModels;
using Neptuo.TemplateEngine.Accounts.Queries;
using Neptuo.TemplateEngine.Web;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Web.DataSources
{
    public class UserAccountDataSource : IListDataSource, IDataSource
    {
        private IUserAccountQuery userQuery;
        private IModelValueProviderFactory factory;

        public int? Key { get; set; }
        public string Username { get; set; }

        public UserAccountDataSource(IUserAccountQuery userQuery, IModelValueProviderFactory factory)
        {
            this.userQuery = userQuery;
            this.factory = factory;
        }

        public object GetItem()
        {
            UserAccount userAccount = null;
            if (Key != null)
                userAccount = userQuery.Get(Key.Value);
            else
                userQuery.Get().FirstOrDefault();

            if (userAccount == null)
                return null;

            return factory.Create(userAccount);
        }

        protected IEnumerable<UserAccount> GetDataOverride(int? pageIndex, int? pageSize)
        {
            IEnumerable<UserAccount> data = userQuery.Get();
            if (!String.IsNullOrEmpty(Username))
                data = data.Where(u => u.Username.Contains(Username));

            if (Key != null)
                data = data.Where(u => u.Key == Key);

            if (pageSize != null)
                data = data.Skip((pageIndex ?? 0) * pageSize.Value).Take(pageSize.Value);

            return data.OrderBy(u => u.Key);
        }

        public IEnumerable GetData(int? pageIndex, int? pageSize)
        {
            foreach (UserAccount userAccount in GetDataOverride(pageIndex, pageSize))
                yield return factory.Create(userAccount);
        }

        public int GetTotalCount()
        {
            return GetDataOverride(null, null).Count();
        }
    }
}
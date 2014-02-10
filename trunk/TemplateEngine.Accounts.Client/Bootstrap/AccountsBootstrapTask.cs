﻿using Neptuo.Bootstrap;
using Neptuo.TemplateEngine.Accounts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Bootstrap
{
    public class AccountsBootstrapTask : IBootstrapTask
    {
        private IDependencyContainer container;

        public AccountsBootstrapTask(IDependencyContainer container)
        {
            Guard.NotNull(container, "container");
            this.container = container;
        }

        public void Initialize()
        {
            container
                .RegisterInstance(new UserRepository());
        }
    }
}

﻿using Neptuo.TemplateEngine.Accounts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class UserAccountEditModel : UserAccountEditCommand
    {
        public bool IsNew
        {
            get { return Key == 0; }
        }

        public UserAccountEditModel()
        { }
    }
}
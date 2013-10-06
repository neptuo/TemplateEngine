﻿using Neptuo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public abstract class UserRole : IKey<int>, IVersion
    {
        public virtual int Key { get; set; }
        public virtual byte[] Version { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}

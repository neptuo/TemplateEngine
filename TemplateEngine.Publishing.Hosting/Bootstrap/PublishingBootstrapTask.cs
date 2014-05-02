﻿using Neptuo.Bootstrap;
using Neptuo.TemplateEngine.Publishing.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.Hosting.Bootstrap
{
    [Module]
    public class PublishingBootstrapTask : IBootstrapTask
    {
        public void Initialize()
        {
            DataContext dbContext = new DataContext();
            dbContext.SaveChanges();
        }
    }
}
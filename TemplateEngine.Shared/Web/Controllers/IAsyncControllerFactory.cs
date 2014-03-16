﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controllers
{
    public interface IAsyncControllerFactory
    {
        IAsyncController Create();
    }
}

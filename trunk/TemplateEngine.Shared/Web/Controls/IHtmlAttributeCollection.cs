﻿using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public interface IHtmlAttributeCollection
    {
        HtmlAttributeCollection Attributes { get; }
    }
}
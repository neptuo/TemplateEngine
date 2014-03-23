﻿using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class SelectControl : ListViewControl, IHtmlAttributeCollection, IAttributeCollection
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public bool IsAddEmpty { get; set; }
        public HtmlAttributeCollection Attributes { get; private set; }

        public SelectControl(IRequestContext requestContext, TemplateContentStorageStack storage, DataContextStorage dataContext, PartialUpdateHelper updateHelper)
            : base(requestContext, storage, dataContext, updateHelper)
        {
            Attributes = new HtmlAttributeCollection();
        }

        public void SetAttribute(string name, string value)
        {
            Attributes[name] = value;
        }
    }
}
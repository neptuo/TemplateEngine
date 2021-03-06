﻿using Neptuo.Linq.Expressions;
using Neptuo.Templates.Compilation.CodeObjects;
using Neptuo.Templates.Compilation.Parsers;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Compilation.Parsers
{
    public class GenericContentControlBuilder<T> : DefaultTypeComponentBuilder
        where T : IControl
    {
        private readonly string tagNameProperty;

        public GenericContentControlBuilder(Expression<Func<T, string>> tagNameProperty)
            : base(typeof(T))
        {
            this.tagNameProperty = TypeHelper.PropertyName(tagNameProperty);
        }

        protected override IComponentCodeObject CreateCodeObject(IContentBuilderContext context, IXmlElement element)
        {
            IComponentCodeObject codeObject = base.CreateCodeObject(context, element);
            codeObject.Properties.Add(new SetPropertyDescriptor(new TypePropertyInfo(GetControlType(element).GetProperty(tagNameProperty)), new PlainValueCodeObject(element.LocalName)));
            return codeObject;
        }
    }
}

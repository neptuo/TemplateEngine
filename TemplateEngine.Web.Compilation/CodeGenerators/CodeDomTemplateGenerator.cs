﻿using Neptuo.Linq.Expressions;
using Neptuo.TemplateEngine.Templates.Compilation.CodeObjects;
using Neptuo.TemplateEngine.Templates.Controls;
using Neptuo.Templates.Compilation.CodeGenerators;
using Neptuo.Templates.Compilation.CodeObjects;
using Neptuo.Templates.Compilation.Parsers;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Compilation.CodeGenerators
{
    public class CodeDomTemplateGenerator : CodeDomComponentGenerator
    {
        public CodeDomTemplateGenerator(IFieldNameProvider fieldNameProvider)
            : base(fieldNameProvider)
        { }

        protected override CodeExpression GenerateCode(CodeObjectExtensionContext context, ComponentCodeObject component, IPropertyDescriptor propertyDescriptor)
        {
            // Remove all properties
            List<IPropertyDescriptor> properties = new List<IPropertyDescriptor>(component.Properties);
            component.Properties.Clear();

            // Generate Bind method for ContentTemplateContent
            ComponentCodeObject templateContent = new ComponentCodeObject(typeof(ContentTemplateContent));
            templateContent.Properties.AddRange(properties);

            string fieldName = GenerateFieldName();
            GenerateBindMethod(context, templateContent, fieldName);

            // Add bind method to properties
            component.Properties.Add(
                new SetPropertyDescriptor(
                    new TypePropertyInfo(
                        component.Type.GetProperty(TypeHelper.PropertyName<ContentTemplate, object>(t => t.BindMethod))
                    ),
                    new MethodReferenceCodeObject(FormatBindMethod(fieldName))
                )
            );

            // Generate component
            return base.GenerateCode(context, component, propertyDescriptor);
        }
    }
}

using Neptuo.Linq.Expressions;
using Neptuo.TemplateEngine.Web.Controls;
using Neptuo.Templates.Compilation.CodeGenerators;
using Neptuo.Templates.Compilation.CodeObjects;
using Neptuo.Templates.Compilation.Parsers;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Compilation.CodeGenerators
{
    public class CodeDomTemplatePropertyTypeGenerator : CodeDomComponentGenerator, ICodeDomPropertyTypeGenerator
    {
        public string ViewPathFormat { get; private set; }

        public CodeDomTemplatePropertyTypeGenerator(IFieldNameProvider fieldNameProvider, string viewPathFormat)
            : base(fieldNameProvider)
        {
            if (viewPathFormat == null)
                throw new ArgumentNullException("viewPathFormat");

            ViewPathFormat = viewPathFormat;
        }

        public CodeExpression GenerateCode(CodeDomPropertyTypeGeneratorContext context, Type type, PropertyInfo propertyInfo)
        {
            try
            {
                //Type type = propertyInfo.DeclaringType;
                Stream fileStream = type.Assembly.GetManifestResourceStream(String.Format(ViewPathFormat, type.Assembly.GetName().Name, type.Name));
                if (fileStream == null)
                    return null;

                string fileContent = new StreamReader(fileStream).ReadToEnd();

                IComponentCodeObject codeObject = new ComponentCodeObject(typeof(StringTemplate));
                codeObject.Properties.Add(
                    new SetPropertyDescriptor(
                        new TypePropertyInfo(
                            typeof(StringTemplate).GetProperty(TypeHelper.PropertyName<StringTemplate, string>(t => t.TemplateContent))
                        ),
                        new PlainValueCodeObject(fileContent)
                    )
                );
                return GenerateCode(new CodeObjectExtensionContext(context.Context, null), codeObject, new SetPropertyDescriptor(new TypePropertyInfo(propertyInfo)));
            }
            catch (FileNotFoundException e)
            {
                Trace.WriteLine(e);
            }
            return null;
        }
    }
}

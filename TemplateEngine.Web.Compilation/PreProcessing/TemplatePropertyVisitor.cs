using Neptuo.Linq.Expressions;
using Neptuo.TemplateEngine.Web.Compilation.Parsers;
using Neptuo.TemplateEngine.Web.Controls;
using Neptuo.Templates.Compilation;
using Neptuo.Templates.Compilation.CodeObjects;
using Neptuo.Templates.Compilation.Parsers;
using Neptuo.Templates.Compilation.PreProcessing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Compilation.PreProcessing
{
    public class TemplatePropertyVisitor : BaseVisitor
    {
        public string ViewPathFormat { get; private set; }
        public IParserService ParserService { get; private set; }

        public TemplatePropertyVisitor(string viewPathFormat, IParserService parserService)
        {
            if (viewPathFormat == null)
                throw new ArgumentNullException("viewPathFormat");

            if (parserService == null)
                throw new ArgumentNullException("parserService");

            ViewPathFormat = viewPathFormat;
            ParserService = parserService;
        }

        protected override void Visit(ICodeObject codeObject)
        {
            ComponentCodeObject componentCodeObject = codeObject as ComponentCodeObject;
            if(componentCodeObject != null)
            {
                IEnumerable<PropertyInfo> properties = GetTemplateProperties(componentCodeObject.Type);
                if (properties.Any())
                {
                    IEnumerable<string> usedProperties = componentCodeObject.Properties.Select(p => p.Property.Name);
                    properties = properties.Where(p => !usedProperties.Contains(p.Name));

                    foreach (PropertyInfo propertyInfo in properties)
                        TrySetPropertyValue(componentCodeObject, propertyInfo);
                }

                //componentCodeObject.Properties.Select()
            }

            IPropertiesCodeObject propertiesCodeObject = codeObject as IPropertiesCodeObject;
            if (propertiesCodeObject != null)
                Visit(propertiesCodeObject.Properties);
        }

        private List<PropertyInfo> GetTemplateProperties(Type sourceType)
        {
            List<PropertyInfo> result = new List<PropertyInfo>();
            foreach (PropertyInfo propertyInfo in sourceType.GetProperties())
            {
                if (typeof(ITemplate).IsAssignableFrom(propertyInfo.PropertyType))
                    result.Add(propertyInfo);
            }
            return result;
        }

        private void TrySetPropertyValue(ComponentCodeObject codeObject, PropertyInfo propertyInfo)
        {
            try
            {
                Type type = codeObject.Type;
                string fileName = String.Format(ViewPathFormat, type.Assembly.GetName().Name, String.Join(".", type.Name, propertyInfo.Name));
                Stream fileStream = type.Assembly.GetManifestResourceStream(fileName);
                if (fileStream == null)
                    return;

                string fileContent = new StreamReader(fileStream).ReadToEnd();
                if (String.IsNullOrWhiteSpace(fileContent))
                    return;

                IPropertyDescriptor propertyDescriptor = TemplatePropertyHelper.PreparePropertyDescriptor(codeObject, new TypePropertyInfo(propertyInfo));

                ICollection<IErrorInfo> errors = new List<IErrorInfo>();
                bool parseResult = ParserService.ProcessContent(fileContent, new DefaultParserServiceContext(Context.DependencyProvider, propertyDescriptor, errors));
                if(!parseResult)
                    throw new CodeDomViewServiceException("Error parsing default template content!", errors, fileContent);
            }
            catch (FileNotFoundException e)
            {
                Trace.WriteLine(e);
            }
        }
    }
}

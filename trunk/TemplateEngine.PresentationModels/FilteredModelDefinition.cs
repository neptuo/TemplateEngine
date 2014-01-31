using Neptuo.PresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.PresentationModels
{
    public class FilteredModelDefinition : ProxyModelDefinition
    {
        private TemplateModelView modelView;

        public FilteredModelDefinition(IModelDefinition modelDefinition, TemplateModelView modelView)
            : base(modelDefinition)
        {
            this.modelView = modelView;
        }

        protected override IEnumerable<IFieldDefinition> RefreshFields()
        {
            List<IFieldDefinition> fields = new List<IFieldDefinition>();
            foreach (IFieldDefinition field in ModelDefinition.Fields)
            {
                if (modelView.Storage[field.Identifier] != null)
                    fields.Add(field);
            }
            return fields;
        }
    }
}

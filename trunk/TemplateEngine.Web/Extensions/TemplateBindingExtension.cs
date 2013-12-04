using Neptuo.Templates.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Extensions
{
    public class TemplateBindingExtension : BindingExtension
    {
        public TemplateBindingExtension(DataContextStorage dataContext, IBindingManager bindingManager, IValueConverterService converterService)
            : base(dataContext, bindingManager, converterService)
        { }

        protected override object GetData()
        {
            return BindingManager.GetValue(Expression, DataContext.Peek("Template"));
        }
    }
}

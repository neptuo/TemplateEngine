using Neptuo.TemplateEngine.Web.Controls;
using Neptuo.Templates;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class RequestComponentManager : ComponentManager
    {
        private NameValueCollection values;

        public RequestComponentManager(NameValueCollection values)
        {
            this.values = values;
        }

        protected override void AfterInitControl(IControl control)
        {
            base.AfterInitControl(control);

            IFormControl formControl = control as IFormControl;
            if (formControl != null && formControl.Name != null && values.AllKeys.Contains(formControl.Name))
                formControl.HandleValue(values[formControl.Name]);
        }
        
    }
}

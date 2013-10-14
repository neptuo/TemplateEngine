using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Navigation.Bootstrap
{
    public static class FormUriServiceRegistration
    {
        public static void SetInstance(IFormUriService formUriService)
        {
            FormUriService.SetInstance(formUriService);
        }
    }
}

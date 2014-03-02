using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Navigation
{
    public class ClientNavigateTo : QueryStringNavigateTo
    {
        public ClientNavigateTo(IVirtualUrlProvider urlProvider, FormUri formUri)
            : base(urlProvider, formUri)
        { }

        protected override void NavigateToUrl(string url)
        {
            throw new NotImplementedException();
        }
    }
}

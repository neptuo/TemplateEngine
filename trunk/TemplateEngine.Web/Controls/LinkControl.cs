using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    [Html("a")]
    public class LinkControl : ContentControlBase
    {
        private IVirtualUrlProvider urlProvider;

        public string Href { get; set; }
        public ICollection<ParameterControl> Parameters { get; set; }

        public LinkControl(IComponentManager componentManager, IVirtualUrlProvider urlProvider)
            : base(componentManager)
        {
            this.urlProvider = urlProvider;
        }

        public override void OnInit()
        {
            base.OnInit();

            Init(Parameters);
        }

        protected override void RenderAttributes(IHtmlWriter writer)
        {
            StringBuilder queryBuilder = new StringBuilder();
            foreach (ParameterControl parameter in Parameters)
                AppendQuery(queryBuilder, parameter.Name, parameter.Value);

            Attributes["href"] = String.Format("{0}{1}",
                urlProvider.ResolveUrl(Href),
                queryBuilder.ToString()
            );
            base.RenderAttributes(writer);
        }

        private void AppendQuery(StringBuilder builder, string key, object value)
        {
            builder.AppendFormat(
                "{2}{0}={1}",
                key,
                value,
                builder.Length == 0 ? "?" : "&"
            );
        }
    }
}

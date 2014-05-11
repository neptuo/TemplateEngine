using Neptuo.TemplateEngine.Providers;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Actual implementation of <see cref="IPaginationControl"/>.
    /// </summary>
    public class PaginationControl : TemplateControl, IPaginationControl
    {
        private ICurrentUrlProvider urlProvider;

        public ITemplate ItemTemplate { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int TotalCount { get; set; }

        public PaginationControl(IComponentManager componentManager, ICurrentUrlProvider urlProvider, TemplateContentStorageStack storage)
            : base(componentManager, storage)
        {
            Guard.NotNull(urlProvider, "urlProvider");
            this.urlProvider = urlProvider;
        }

        public override void OnInit()
        {
            //base.OnInit();
        }

        public override void Render(IHtmlWriter writer)
        {
            //base.Render(writer);
            
            writer
                .Tag("ul")
                .Attribute("class", "pagination pagination-sm");

            for (int i = 0; i < (int)Math.Ceiling((decimal)TotalCount / PageSize); i++)
            {
                writer
                    .Tag("li")
                    .Attribute("class", (PageIndex == i) ? "active" : "")
                        .Tag("a")
                        .Attribute("href", urlProvider.GetCurrentUrl() + ((i != 0) ? ("?PageIndex=" + i) : ""))
                        .Content(i + 1)
                        .CloseFullTag()
                    .CloseFullTag();
            }

            writer
                .CloseFullTag();
        }
    }
}

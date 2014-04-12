using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class PaginationControl : TemplateControl, IPaginationControl
    {
        public ITemplate ItemTemplate { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int TotalCount { get; set; }

        public PaginationControl(IComponentManager componentManager, TemplateContentStorageStack storage)
            : base(componentManager, storage)
        { }

        public override void OnInit()
        {
            //base.OnInit();
        }

        public override void Render(IHtmlWriter writer)
        {
            //base.Render(writer);

            if (PageSize != null)
            {
                writer
                    .Tag("ul")
                    .Attribute("class", "pagination pagination-sm");

                for (int i = 0; i < (int)Math.Ceiling((decimal)TotalCount / PageSize); i++)
                {
                    writer
                        .Tag("li")
                        .Attribute("class", (PageIndex == i) ? "active" : "")
                            .Tag("a")
                            .Attribute("href", (i != 0) ? ("?PageIndex=" + i) : "?")
                            .Content(i + 1)
                            .CloseFullTag()
                        .CloseFullTag();
                }

                writer
                    .CloseFullTag();
            }
        }
    }
}

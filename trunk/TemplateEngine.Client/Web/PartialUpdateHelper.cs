using Neptuo.Templates;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class PartialUpdateHelper : IControl
    {
        private IGuidProvider guidProvider;
        private string partialElementGuid;

        private bool isRenderCalled = false;
        private bool isDataLoaded = false;

        public event RenderEventHandler RenderContent;

        public PartialUpdateHelper(IGuidProvider guidProvider)
        {
            Guard.NotNull(guidProvider, "guidProvider");
            this.guidProvider = guidProvider;
        }

        public void OnInit()
        {
            Guard.NotNull(RenderContent, "RenderContent");
            partialElementGuid = guidProvider.Next();
        }

        public void Render(IHtmlWriter writer)
        {
            if (!isDataLoaded)
            {
                isRenderCalled = true;

                writer
                    .Tag("div")
                    .Attribute("data-partial", partialElementGuid)
                    .Content("Loading data...")
                    .CloseFullTag();

                return;
            }
            else
            {
                if (RenderContent != null)
                    RenderContent(writer);
            }
        }

        public void OnDataLoaded()
        {
            isDataLoaded = true;

            if (isRenderCalled)
            {
                StringWriter stringWriter = new StringWriter();
                HtmlTextWriter writer = new HtmlTextWriter(stringWriter);

                if (RenderContent != null)
                    RenderContent(writer);

                InitScript.UpdateContent(partialElementGuid, stringWriter);
            }
        }
    }

    public delegate void RenderEventHandler(IHtmlWriter writer);
}

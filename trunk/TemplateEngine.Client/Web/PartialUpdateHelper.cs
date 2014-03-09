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
        private IPartialWriter partialWriter;
        private IMainView mainView;
        private string partialElementGuid;

        private bool isRenderCalled = false;
        private bool isDataLoaded = false;

        public event RenderEventHandler RenderContent;

        public PartialUpdateHelper(IGuidProvider guidProvider, IPartialWriter partialWriter, IMainView mainView)
        {
            Guard.NotNull(guidProvider, "guidProvider");
            Guard.NotNull(partialWriter, "partialWriter");
            Guard.NotNull(mainView, "mainView");
            this.guidProvider = guidProvider;
            this.partialWriter = partialWriter;
            this.mainView = mainView;
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
                partialWriter.WritePlaceholder(writer, partialElementGuid);
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

                mainView.UpdateView(partialElementGuid, stringWriter);
            }
        }
    }

    public delegate void RenderEventHandler(IHtmlWriter writer);
}

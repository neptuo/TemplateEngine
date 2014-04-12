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
        private IMainView mainView;
        private string partialElementGuid;

        private bool isRenderCalled = false;
        private bool isDataLoaded = false;
        private ErrorModel error = null;

        public event RenderEventHandler RenderContent;

        public PartialUpdateHelper(IGuidProvider guidProvider, IMainView mainView)
        {
            Guard.NotNull(guidProvider, "guidProvider");
            Guard.NotNull(mainView, "mainView");
            this.guidProvider = guidProvider;
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
                mainView.WritePlaceholder(writer, partialElementGuid);
                return;
            }
            else
            {
                if (error != null)
                    mainView.UpdateError(partialElementGuid, error);
                else if (RenderContent != null)
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

        public void OnError(ErrorModel error)
        {
            isDataLoaded = true;
            if (isRenderCalled)
                mainView.UpdateError(partialElementGuid, error);
            else
                this.error = error;
        }
    }

    public delegate void RenderEventHandler(IHtmlWriter writer);
}

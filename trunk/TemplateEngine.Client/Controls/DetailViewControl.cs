using Neptuo.Templates;
using SharpKit.jQuery;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class DetailViewControl : TemplateControl
    {
        public DataSources.IDataSource Source { get; set; }
        protected DataContextStorage DataContext { get; private set; }
        protected IGuidProvider GuidProvider { get; private set; }
        private string partialElementGuid;

        public DetailViewControl(IComponentManager componentManager, TemplateContentStorageStack storage, DataContextStorage dataContext, IGuidProvider guidProvider)
            : base(componentManager, storage)
        {
            DataContext = dataContext;
            GuidProvider = guidProvider;
        }

        public override void OnInit()
        {
            InitComponent(Source);

            if (Source == null)
                throw new InvalidOperationException("Missing data source.");

            Source.GetItem(OnLoadData);
            partialElementGuid = GuidProvider.Next();
        }

        private bool isRenderCalled = false;
        private bool isDataLoaded = false;
        public override void Render(IHtmlWriter writer)
        {
            if(!isDataLoaded)
            {
                isRenderCalled = true;
                
                writer
                    .Tag("div")
                    .Attribute("data-partial", partialElementGuid)
                    .Content("Loading data...")
                    .CloseFullTag();

                return;
            }

            base.Render(writer);
        }

        private void OnLoadData(object data)
        {
            isDataLoaded = true;

            DataContext.Push(data);
            base.OnInit();
            DataContext.Pop();

            if (isRenderCalled)
            {
                StringWriter stringWriter = new StringWriter();
                HtmlTextWriter writer = new HtmlTextWriter(stringWriter);

                Render(writer);
                InitScript.UpdateContent(partialElementGuid, stringWriter);
            }
        }
    }
}

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

        public DetailViewControl(IComponentManager componentManager, TemplateContentStorageStack storage, DataContextStorage dataContext)
            : base(componentManager, storage)
        {
            DataContext = dataContext;
        }

        public override void OnInit()
        {
            InitComponent(Source);

            if (Source == null)
                throw new InvalidOperationException("Missing data source.");

            Source.GetItem(OnLoadData);
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
                    .Attribute("data-partial", "detailviewcontrol")
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
                //TODO: Render to temp element...
                jQuery target = new jQuery("div[data-partial=detailviewcontrol]");

                StringWriter stringWriter = new StringWriter();
                HtmlTextWriter writer = new HtmlTextWriter(stringWriter);

                Render(writer);
                target.replaceWith(stringWriter.ToString());
            }
        }
    }
}

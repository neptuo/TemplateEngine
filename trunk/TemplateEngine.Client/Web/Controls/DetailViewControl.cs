using Neptuo.TemplateEngine.Web.DataSources;
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
        public IDataSource Source { get; set; }
        protected DataContextStorage DataContext { get; private set; }
        protected PartialUpdateHelper UpdateHelper { get; private set; }

        public DetailViewControl(IComponentManager componentManager, TemplateContentStorageStack storage, DataContextStorage dataContext, PartialUpdateHelper updateHelper)
            : base(componentManager, storage)
        {
            DataContext = dataContext;
            UpdateHelper = updateHelper;
        }

        public override void OnInit()
        {
            InitComponent(Source);

            if (Source == null)
                throw new InvalidOperationException("Missing data source.");

            Source.GetItem(OnLoadData);

            UpdateHelper.RenderContent += OnRenderContent;
            UpdateHelper.OnInit();
        }

        private void OnRenderContent(IHtmlWriter writer)
        {
            base.Render(writer);
        }

        public override void Render(IHtmlWriter writer)
        {
            UpdateHelper.Render(writer);
        }

        private void OnLoadData(object data)
        {
            DataContext.Push(data);
            base.OnInit();
            DataContext.Pop();

            UpdateHelper.OnDataLoaded();
        }
    }
}

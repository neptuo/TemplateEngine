using Neptuo.TemplateEngine.Templates.DataSources;
using Neptuo.TemplateEngine.Web;
using Neptuo.Templates;
using SharpKit.jQuery;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    public class ClientDetailViewControl : TemplateControl
    {
        public IClientDataSource Source { get; set; }
        protected DataContextStorage DataContext { get; private set; }
        protected PartialUpdateHelper UpdateHelper { get; private set; }
        protected AsyncNotifyService NotifyService { get; private set; }

        public ClientDetailViewControl(IComponentManager componentManager, TemplateContentStorageStack storage, DataContextStorage dataContext, PartialUpdateHelper updateHelper, AsyncNotifyService notifyService)
            : base(componentManager, storage)
        {
            DataContext = dataContext;
            UpdateHelper = updateHelper;
            NotifyService = notifyService;
        }

        public override void OnInit()
        {
            InitComponent(Source);

            if (Source == null)
                throw new InvalidOperationException("Missing data source.");

            UpdateHelper.RenderContent += OnRenderContent;
            UpdateHelper.OnInit();

            NotifyService.Register(this);
            Source.GetItem(OnLoadData, OnError);
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
            NotifyService.NotifyDone(this);
        }

        private void OnError(ErrorModel model)
        {
            UpdateHelper.OnError(model);
            NotifyService.NotifyDone(this);
        }
    }
}

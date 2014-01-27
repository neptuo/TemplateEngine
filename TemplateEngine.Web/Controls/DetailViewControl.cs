using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class DetailViewControl : TemplateControl
    {
        public IDataSource Source { get; set; }
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

            DataContext.Push(Source.GetItem());
            base.OnInit();
            DataContext.Pop();
        }
    }
}

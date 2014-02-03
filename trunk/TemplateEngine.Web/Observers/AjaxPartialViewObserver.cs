using Neptuo.Templates;
using Neptuo.Templates.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Observers
{
    public class AjaxPartialViewObserver : IObserver
    {
        private DataContextStorage dataContext;

        public string PartialView { get; set; }

        public AjaxPartialViewObserver(DataContextStorage dataContext)
        {
            this.dataContext = dataContext;
        }

        public void OnInit(ObserverEventArgs e)
        { }

        public void Render(ObserverEventArgs e, IHtmlWriter writer)
        {
            string value = dataContext.Peek(PartialView) as string;
            if (value != null)
                writer.Attribute("data-partial", value);
        }
    }
}

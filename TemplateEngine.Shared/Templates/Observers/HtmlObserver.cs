using Neptuo.Templates;
using Neptuo.Templates.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Observers
{
    public class HtmlObserver : IObserver
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }

        public void OnInit(ObserverEventArgs e)
        {
            IAttributeCollection htmlControl = e.Target as IAttributeCollection;
            if(htmlControl == null)
                return;

            if (!String.IsNullOrEmpty(ID))
                htmlControl.SetAttribute("id", ID);

            if (!String.IsNullOrEmpty(Name))
                htmlControl.SetAttribute("name", Name);

            if (!String.IsNullOrEmpty(Class))
                htmlControl.SetAttribute("class", Class);

            if (!String.IsNullOrEmpty(Style))
                htmlControl.SetAttribute("style", Style);
        }

        public void Render(ObserverEventArgs e, IHtmlWriter writer)
        { }
    }
}

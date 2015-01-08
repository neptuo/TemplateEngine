using Neptuo.TemplateEngine.FluentConsole.Bootstrap;
using SharpKit.Html;
using SharpKit.jQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.FluentConsole
{
    [Component("ConsoleDesk")]
    public class ConsoleDesk : IRunnable
    {
        public void Start()
        {
            //HtmlContext.alert("Loading console desk");

            new jQuery(HtmlContext.window).on("resize", OnWindowResize);
            OnWindowResize(null);
        }

        private void OnWindowResize(Event e)
        {
            new jQuery("body")
                .width(HtmlContext.window.innerWidth)
                .height(HtmlContext.window.innerHeight);
        }
    }
}

using Neptuo.TemplateEngine.Navigation;
using Neptuo.TemplateEngine.Providers;
using Neptuo.TemplateEngine.Web;
using Neptuo.Templates;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Enables putting navigation rules into views.
    /// </summary>
    [DefaultProperty("Items")]
    public class NavigationControl : ControlBase
    {
        protected string Navigation { get; private set; }
        protected INavigator Navigator { get; private set; }
        public ICollection<NavigationItem> Items { get; set; }

        public NavigationControl(IComponentManager componentManager, INavigator navigator, string navigation)
            : base(componentManager)
        {
            Navigator = navigator;
            Navigation = navigation;
        }

        public override void OnInit()
        {
            InitComponents(Items);
            {
                if (Items != null)
                {
                    foreach (NavigationItem item in Items)
                    {
                        if (item.On == Navigation)
                        {
                            Navigator.Open(item.To);
                            return;
                        }
                    }
                }
            }
        }
    }
}

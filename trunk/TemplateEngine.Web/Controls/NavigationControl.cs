using Neptuo.TemplateEngine.Navigation;
using Neptuo.Templates;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    [DefaultProperty("Items")]
    public class NavigationControl : ControlBase
    {
        protected NavigationCollection Navigations { get; private set; }
        protected INavigator Navigator { get; private set; }
        public ICollection<NavigationItem> Items { get; set; }

        public NavigationControl(IComponentManager componentManager, INavigator navigator, NavigationCollection navigations)
            : base(componentManager)
        {
            Navigator = navigator;
            Navigations = navigations;
        }

        public override void OnInit()
        {
            Init(Items);
            foreach (string name in Navigations)
            {
                foreach (NavigationItem item in Items)
                {
                    if(item.Name == name)
                        Navigator.Open((FormUri)item.To);
                }
            }
        }
    }
}

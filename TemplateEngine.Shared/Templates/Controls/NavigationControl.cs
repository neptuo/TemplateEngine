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
    [DefaultProperty("Items")]
    public class NavigationControl : ControlBase
    {
        protected NavigationCollection Navigations { get; private set; }
        protected GlobalNavigationCollection GlobalNavigations { get; private set; }
        protected INavigator Navigator { get; private set; }
        public ICollection<NavigationItem> Items { get; set; }

        public NavigationControl(IComponentManager componentManager, INavigator navigator, NavigationCollection navigations, GlobalNavigationCollection globalNavigations)
            : base(componentManager)
        {
            Navigator = navigator;
            Navigations = navigations;
            GlobalNavigations = globalNavigations;
        }

        public override void OnInit()
        {
            InitComponents(Items);
            foreach (string name in Navigations)
            {
                if (Items != null)
                {
                    foreach (NavigationItem item in Items)
                    {
                        if (item.Name == name)
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

using Neptuo.Lifetimes;
using Neptuo.ObjectBuilder;
using Neptuo.ObjectBuilder.Lifetimes.Mapping;
using Neptuo.TemplateEngine.PresentationModels;
using Neptuo.Templates;
using SharpKit.Html;
using SharpKit.jQuery;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public static class InitScript
    {
        private static IDependencyContainer objectBuilder;
        private static IViewActivator viewActivator;

        private static IDependencyContainer CreateDependencyContainer()
        {
            DependencyContainer container = new DependencyContainer();
            container
                .Map(typeof(SingletonLifetime), new SingletonLifetimeMapper());

            container
                .RegisterType<IStackStorage<IViewStorage>, StackStorage<IViewStorage>>()
                .RegisterType<IVirtualUrlProvider, UrlProvider>()
                .RegisterType<ICurrentUrlProvider, UrlProvider>()
                .RegisterType<IParameterProviderFactory, ParameterProviderFactory>()
                .RegisterType<IParameterProvider, ParameterProvider>()
                .RegisterType<IBindingManager, BindingManagerBase>()
                .RegisterType<IValueConverterService, ValueConverterService>()
                .RegisterInstance(new TemplateContentStorageStack())
                .RegisterInstance(new DataContextStorage())
                .RegisterInstance<IGuidProvider>(new SequenceGuidProvider("guid", 1))
                .RegisterType<IViewActivator, StaticViewActivator>(new SingletonLifetime());

            return container;
        }

        public static void Init()
        {
            objectBuilder = CreateDependencyContainer();
            viewActivator = objectBuilder.Resolve<IViewActivator>();

            new jQuery(() => { new jQuery("body").@delegate("a", "click", OnLinkClick); });
        }

        public static void UpdateContent(string partialGuid, TextWriter content)
        {
            jQuery target = new jQuery("div[data-partial=" + partialGuid + "]");
            target.replaceWith(content.ToString());

            target.find("a").click(OnLinkClick);
        }

        public static string MapView(string url)
        {
            if (url.StartsWith("/Home.aspx"))
                return "~/Views/Home.view";

            if (url.StartsWith("/Accounts/UserList.aspx"))
                return "~/Views/Accounts/UserList.view";
            
            if (url.StartsWith("/Accounts/UserEdit.aspx"))
                return "~/Views/Accounts/UserEdit.view";

            if (url.StartsWith("/Accounts/RoleList.aspx"))
                return "~/Views/Accounts/RoleList.view";
            
            if (url.StartsWith("/Accounts/RoleEdit.aspx"))
                return "~/Views/Accounts/RoleEdit.view";

            return null;
        }

        public static void OnLinkClick(Event e)
        {
            jQuery link = new jQuery(e.currentTarget);
            e.preventDefault();
            
            RenderViewFromLink(link);
        }

        private static void RenderViewFromLink(jQuery link)
        {
            string newUrl = link.attr("href");
            string viewPath = MapView(newUrl);

            if (viewPath == null)
            {
                HtmlContext.alert("No view for: " + newUrl);
                return;
            }

            HtmlContext.history.pushState(viewPath, link.html(), newUrl);

            IDependencyContainer container = objectBuilder.CreateChildContainer();
            container.RegisterInstance<IComponentManager>(new ComponentManager());

            StringWriter writer = new StringWriter();
            var view = viewActivator.CreateView(viewPath);
            view.Setup(new BaseViewPage(container.Resolve<IComponentManager>()), container.Resolve<IComponentManager>(), container);
            view.CreateControls();
            view.Init();
            view.Render(new ExtendedHtmlTextWriter(writer));
            view.Dispose();

            new jQuery("#target").html(writer.ToString()).find('a').click(OnLinkClick);
        }
    }

    public class UrlProvider : IVirtualUrlProvider, ICurrentUrlProvider
    {
        public string ResolveUrl(string path)
        {
            return path.Replace("~/", "/");
        }

        public string GetCurrentUrl()
        {
            return HtmlContext.location.href;
        }
    }

    public class ParameterProviderFactory : IParameterProviderFactory
    {
        public IParameterProvider Provider(ParameterProviderType providerType)
        {
            return new ParameterProvider();
        }
    }

    public class ParameterProvider : IParameterProvider
    {
        public IEnumerable<string> Keys
        {
            get { return new List<string>(); }
        }

        public bool TryGet(string key, out object value)
        {
            value = null;
            return false;
        }
    }



}

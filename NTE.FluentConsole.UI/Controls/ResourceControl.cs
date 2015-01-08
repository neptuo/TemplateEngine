using Neptuo.Templates;
using Neptuo.Templates.Controls;
using Neptuo.Web.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Neptuo.TemplateEngine.FluentConsole.UI.Controls
{
    public class ResourceControl : IControl
    {
        private IResourceCollection collection;
        private IResource resource;
        private IVirtualUrlProvider urlProvider;

        public string Name { get; set; }

        public ResourceControl(IResourceCollection collection, IVirtualUrlProvider urlProvider)
        {
            Guard.NotNull(collection, "collection");
            Guard.NotNull(urlProvider, "urlProvider");
            this.collection = collection;
            this.urlProvider = urlProvider;
        }

        public void OnInit()
        {
            if (!collection.TryGet(Name, out resource))
                throw new ArgumentException(String.Format("Can't find resource with name '{0}'.", Name), "Name");
        }

        public void Render(IHtmlWriter writer)
        {
            if(resource == null)
                throw new InvalidOperationException("Can't render ResourceControl without resource.");

            RenderResource(writer, resource);
        }

        private void RenderResource(IHtmlWriter writer, IResource resource)
        {
            foreach (IResource dependency in resource.EnumerateDependencies())
                RenderResource(writer, dependency);

            foreach (IStylesheet stylesheet in resource.EnumerateStylesheets())
            {
                writer.Tag("link")
                    .Attribute("rel", "stylesheet")
                    .Attribute("href", urlProvider.ResolveUrl(stylesheet.Source))
                    .CloseTag();
            }

            foreach (IJavascript javascript in resource.EnumerateJavascripts())
            {
                writer.Tag("script")
                    .Attribute("src", urlProvider.ResolveUrl(javascript.Source))
                    .CloseFullTag();
            }
        }
    }
}
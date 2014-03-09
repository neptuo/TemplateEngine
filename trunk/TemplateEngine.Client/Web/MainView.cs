using Neptuo.Templates;
using SharpKit.Html;
using SharpKit.JavaScript;
using SharpKit.jQuery;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class MainView : IMainView
    {
        protected IViewActivator ViewActivator { get; private set; }

        public event Action<string, string[]> OnLinkClick;
        public event Action<FormRequestContext> OnPostFormSubmit;
        public event Action<string, string[]> OnGetFormSubmit;

        public MainView(IViewActivator viewActivator)
        {
            Guard.NotNull(viewActivator, "viewActivator");
            ViewActivator = viewActivator;

            new jQuery(() =>
            {
                jQuery body = new jQuery("body");

                body.@delegate("a", "click", OnLinkClickInternal);
                body.@delegate("button", "click", OnButtonClickInternal);
                body.@delegate("form", "submit", OnFormSubmitInternal);
            });
        }

        #region Navigation events on DOM

        private string[] GetToUpdateFromElement(jQuery element)
        {
            string value = element.data("toupdate").As<string>();
            if (String.IsNullOrEmpty(value))
                return null;

            return value.Split(',');
        }

        private void OnLinkClickInternal(Event e)
        {
            jQuery link = new jQuery(e.currentTarget);

            string newUrl = link.attr("href");
            string[] toUpdate = GetToUpdateFromElement(link);

            if (OnLinkClick != null)
                OnLinkClick(newUrl, toUpdate);

            e.preventDefault();
        }

        private void OnButtonClickInternal(Event e)
        {
            jQuery button = new jQuery(e.currentTarget);
            string buttonName = button.attr("name");
            button.parents("form").first().data("button", buttonName);
        }

        private void OnFormSubmitInternal(Event e)
        {
            jQuery form = new jQuery(e.currentTarget);

            string buttonName = form.data("button").As<string>();
            if (String.IsNullOrEmpty(buttonName))
                buttonName = form.find("button:first").attr("name");

            string formUrl = form.attr("action") ?? HtmlContext.location.href;
            string[] toUpdate = GetToUpdateFromElement(form) ?? new string[] { "Body" };

            if (form.@is("[method]") && form.attr("method").toLocaleLowerCase() == "post")
            {
                JsArray formData = form.serializeArray();
                if (!String.IsNullOrEmpty(buttonName))
                {
                    JsObject submitButton = new JsObject();
                    submitButton["name"] = buttonName;
                    submitButton["value"] = null;
                    formData.push(submitButton);
                }

                FormRequestContext context = new FormRequestContext(toUpdate, formData, buttonName, formUrl);

                if (OnPostFormSubmit != null)
                    OnPostFormSubmit(context);
            }
            else
            {
                // For "get" forms, serialize to url and redirect
                string formData = form.serialize();
                int queryIndex = formUrl.IndexOf("?");
                if (queryIndex > 0)
                    formUrl = formUrl.Substring(0, queryIndex);

                formUrl += "?" + formData;

                if (OnGetFormSubmit != null)
                    OnGetFormSubmit(formUrl, toUpdate);
            }

            e.preventDefault();
        }

        #endregion

        #region Rendering view

        public virtual void RenderView(string viewPath, string[] toUpdate, IDependencyContainer dependencyContainer)
        {
            ClientExtendedComponentManager componentManager = new ClientExtendedComponentManager(toUpdate);
            dependencyContainer
                .RegisterInstance<IComponentManager>(componentManager)
                .RegisterInstance<IPartialUpdateWriter>(componentManager)
                .RegisterInstance<NavigationCollection>(new NavigationCollection());

            StringWriter writer = new StringWriter();
            var view = ViewActivator.CreateView(viewPath);
            view.Setup(new BaseViewPage(componentManager), componentManager, dependencyContainer);
            view.CreateControls();
            view.Init();
            view.Render(new ExtendedHtmlTextWriter(writer));
            view.Dispose();
        }

        #endregion
    }
}

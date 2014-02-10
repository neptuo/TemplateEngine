using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Web.Controls.DesignData;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class LinkControl : HtmlContentControlBase
    {
        private IVirtualUrlProvider urlProvider;
        private ICurrentUrlProvider currentUrl;
        private IParameterProviderFactory parameterFactory;

        public string Href { get; set; }

        [Hint("Replace for Content property for setting via attribute.")]
        public string Text { get; set; }

        [Hint("Can contain 'All', 'Query', 'Form' or comma separated list of parameter names.")]
        public string CopyParameters { get; set; }
        public ICollection<ParameterControl> Parameters { get; set; }

        [Hint("Setting to false, disable adding 'active' css class when matching url with current.")]
        [DefaultValue(true)]
        public bool AllowActive { get; set; }

        public LinkControl(IComponentManager componentManager, IVirtualUrlProvider urlProvider, ICurrentUrlProvider currentUrl, IParameterProviderFactory parameterFactory)
            : base(componentManager, "a")
        {
            this.urlProvider = urlProvider;
            this.currentUrl = currentUrl;
            this.parameterFactory = parameterFactory;
        }

        public override void OnInit()
        {
            base.OnInit();

            if (Href == null)
                throw new ArgumentNullException("Href");

            if (AllowActive && currentUrl.GetCurrentUrl().EndsWith(Href))
                Attributes["class"] = "active";

            if (!String.IsNullOrEmpty(Text))
                Content = new List<object> { Text };

            InitComponents(Parameters);
        }

        protected override void RenderAttributes(IHtmlWriter writer)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            if (!String.IsNullOrEmpty(CopyParameters))
            {
                string copy = CopyParameters.ToLowerInvariant();
                if (copy == "all")
                    CopyParameterCollection(parameters, parameterFactory.Provider(ParameterProviderType.All).GetAllParameters());
                else if (copy == "query")
                    CopyParameterCollection(parameters, parameterFactory.Provider(ParameterProviderType.Url).GetAllParameters());
                else if (copy == "form")
                    CopyParameterCollection(parameters, parameterFactory.Provider(ParameterProviderType.Form).GetAllParameters());
                else
                    CopySelectedParameters(parameters, CopyParameters.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            }

            StringBuilder queryBuilder = new StringBuilder();
            if (Parameters != null)
            {
                foreach (ParameterControl parameter in Parameters)
                    parameters[parameter.Name] = parameter.Value;
            }

            foreach (var parameter in parameters)
                AppendQuery(queryBuilder, parameter.Key, parameter.Value);

            Attributes["href"] = String.Format("{0}{1}",
                urlProvider.ResolveUrl(Href),
                queryBuilder.ToString()
            );
            base.RenderAttributes(writer);
        }

        private void AppendQuery(StringBuilder builder, string key, object value)
        {
            builder.AppendFormat(
                "{2}{0}={1}",
                key,
                value,
                builder.Length == 0 ? "?" : "&"
            );
        }

        private void CopyParameterCollection(Dictionary<string, object> parameters, params Dictionary<string, object>[] collections)
        {
            foreach (Dictionary<string, object> collection in collections)
            {
                foreach (var parameter in collection.Keys)
                    parameters[parameter] = collection[parameter];
            }
        }

        private void CopySelectedParameters(Dictionary<string, object> parameters, IEnumerable<string> selectedParameters)
        {
            HashSet<string> currentNames = new HashSet<string>(parameterFactory.Provider(ParameterProviderType.All).Keys.Select(p => p.ToLowerInvariant()));
            object value;
            foreach (string paramName in selectedParameters)
            {
                if (currentNames.Contains(paramName.ToLowerInvariant()) && parameterFactory.Provider(ParameterProviderType.All).TryGet(paramName, out value))
                    parameters[paramName] = value;
            }
        }
    }
}

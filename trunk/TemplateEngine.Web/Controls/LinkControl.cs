using Neptuo.TemplateEngine.Web.Controls.DesignData;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Web.Controls
{
    [Html("a")]
    public class LinkControl : HtmlContentControlBase
    {
        private IVirtualUrlProvider urlProvider;
        private HttpRequestBase httpRequest;

        public string Href { get; set; }

        [Hint("Replace for Content property for setting via attribute.")]
        public string Text { get; set; }

        [Hint("Can contain 'All', 'Query', 'Form' or comma separated list of parameter names.")]
        public string CopyParameters { get; set; }
        public ICollection<ParameterControl> Parameters { get; set; }

        public LinkControl(IComponentManager componentManager, IVirtualUrlProvider urlProvider, HttpRequestBase httpRequest)
            : base(componentManager)
        {
            this.urlProvider = urlProvider;
            this.httpRequest = httpRequest;
        }

        public override void OnInit()
        {
            base.OnInit();

            if (Href == null)
                throw new ArgumentNullException("Href");

            if (httpRequest.AppRelativeCurrentExecutionFilePath.EndsWith(Href))
                Attributes["class"] = "active";

            if (!String.IsNullOrEmpty(Text))
                Content = new List<object> { Text };

            Init(Parameters);
        }

        protected override void RenderAttributes(IHtmlWriter writer)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            if (!String.IsNullOrEmpty(CopyParameters))
            {
                string copy = CopyParameters.ToLowerInvariant();
                if (copy == "all")
                    CopyParameterCollection(parameters, httpRequest.QueryString, httpRequest.Form);
                else if (copy == "query")
                    CopyParameterCollection(parameters, httpRequest.QueryString);
                else if (copy == "form")
                    CopyParameterCollection(parameters, httpRequest.Form);
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

        private void CopyParameterCollection(Dictionary<string, object> parameters, params NameValueCollection[] collections)
        {
            foreach (NameValueCollection collection in collections)
            {
                foreach (var parameter in collection.AllKeys)
                    parameters[parameter] = collection.Get(parameter);
            }
        }

        private void CopySelectedParameters(Dictionary<string, object> parameters, IEnumerable<string> selectedParameters)
        {
            HashSet<string> currentNames = new HashSet<string>(httpRequest.Params.AllKeys.Select(p => p.ToLowerInvariant()));
            foreach (string paramName in selectedParameters)
            {
                if (currentNames.Contains(paramName.ToLowerInvariant()))
                    parameters.Add(paramName, httpRequest.Params[paramName]);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Navigation
{
    public class FormUri
    {
        private string identifier;
        private string url;

        internal FormUri(string identifier, string url)
        {
            if (identifier == null)
                throw new ArgumentNullException("identifier");

            if (url == null)
                throw new ArgumentNullException("url");

            this.identifier = identifier;
            this.url = url;
        }

        public string Identifier()
        {
            return identifier;
        }

        public string Url()
        {
            return url;
        }

        //internal void SetUrl(string url)
        //{
        //    if (url == null)
        //        throw new ArgumentNullException("url");

        //    this.url = url;
        //}

        public static implicit operator FormUri(string uri)
        {
            FormUri formUri;
            if (FormUriService.Instance.TryGet(uri, out formUri))
                return formUri;

            return null; //TODO: Throw new Expception?
        }
    }
}

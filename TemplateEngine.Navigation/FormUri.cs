using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Navigation
{
    /// <summary>
    /// Registed url to identifier.
    /// </summary>
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

        /// <summary>
        /// Converts string identifier to registration.
        /// </summary>
        /// <param name="uri">Registered identifier.</param>
        public static explicit operator FormUri(string uri)
        {
            FormUri formUri;
            if (FormUriTable.Repository.TryGet(uri, out formUri))
                return formUri;

            throw new ArgumentOutOfRangeException("uri", String.Format("This '{0}' isn't registered form uri.", uri));
        }
    }
}

using Neptuo.TemplateEngine.Navigation.Bootstrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Navigation
{
    public class DefaultFormUriService : IFormUriService, IFormUriRegistry
    {
        protected Dictionary<string, FormUri> Storage;

        public DefaultFormUriService()
        {
            Storage = new Dictionary<string, FormUri>();
        }

        public IFormUriRegistry Register(string identifier, string url)
        {
            if (identifier == null)
                throw new ArgumentNullException("identifier");

            if(url == null)
                throw new ArgumentNullException("url");

            FormUri formUri = new FormUri(identifier, url);
            Storage[identifier] = formUri;
            return this;
        }

        public bool TryGet(string identifier, out FormUri formUri)
        {
            return Storage.TryGetValue(identifier, out formUri);
        }
    }
}

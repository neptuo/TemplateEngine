using Neptuo.TemplateEngine.Web.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class TemplateContentStorage
    {
        private TemplateContentStorage parent;
        private Dictionary<string, TemplateContentControl> storage = new Dictionary<string, TemplateContentControl>();

        internal TemplateContentStorage(TemplateContentStorage parent)
        {
            this.parent = parent;
        }

        public void Add(string key, TemplateContentControl content)
        {
            storage[key] = content;
        }

        public void AddRange(IEnumerable<TemplateContentControl> contents)
        {
            if (contents == null)
                throw new ArgumentNullException("contents");

            foreach (TemplateContentControl content in contents)
                Add(content.Name, content);
        }

        public bool ContainsKey(string key)
        {
            if (storage.ContainsKey(key))
                return true;

            if (parent == null)
                return false;

            return parent.ContainsKey(key);
        }

        public TemplateContentControl Get(string key)
        {
            if (storage.ContainsKey(key))
                return storage[key];

            if (parent == null)
                throw new ArgumentOutOfRangeException("key", String.Format("Missing key '{0}'.", key));

            return parent.Get(key);
        }
    }
}

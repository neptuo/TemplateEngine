using Neptuo.TemplateEngine.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates
{
    /// <summary>
    /// Storage of <see cref="TemplateContentControl"/> objects.
    /// </summary>
    public class TemplateContentStorage
    {
        /// <summary>
        /// Parent storage.
        /// </summary>
        private TemplateContentStorage parent;
        private Dictionary<string, TemplateContentControl> storage = new Dictionary<string, TemplateContentControl>();

        internal TemplateContentStorage(TemplateContentStorage parent)
        {
            this.parent = parent;
        }

        /// <summary>
        /// Adds new item.
        /// </summary>
        public void Add(string key, TemplateContentControl content)
        {
            storage[key] = content;
        }

        /// <summary>
        /// Adds range of new items.
        /// </summary>
        public void AddRange(IEnumerable<TemplateContentControl> contents)
        {
            if (contents == null)
                throw new ArgumentNullException("contents");

            foreach (TemplateContentControl content in contents)
                Add(content.Name, content);
        }

        /// <summary>
        /// Returns true if current or parent contains item with <paramref name="key"/>.
        /// </summary>
        /// <param name="key">Template content name.</param>
        /// <returns>True if current or parent contains item with <paramref name="key"/>.</returns>
        public bool ContainsKey(string key)
        {
            if (storage.ContainsKey(key))
                return true;

            if (parent == null)
                return false;

            return parent.ContainsKey(key);
        }

        /// <summary>
        /// Gets item with <paramref name="key"/>.
        /// Also searches parents.
        /// </summary>
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

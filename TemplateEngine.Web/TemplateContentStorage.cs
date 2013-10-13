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
        private Dictionary<string, TemplateContentControl> storage = new Dictionary<string, TemplateContentControl>();

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
            return storage.ContainsKey(key);
        }

        public TemplateContentControl Get(string key)
        {
            return storage[key];
        }
    }
}

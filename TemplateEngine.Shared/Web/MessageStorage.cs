using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class MessageStorage
    {
        private Dictionary<string, List<Message>> storage = new Dictionary<string, List<Message>>();

        public void Add(string group, string key, string text, MessageType type = MessageType.Error)
        {
            if(group == null)
                group = String.Empty;

            List<Message> list;
            if (!storage.TryGetValue(group, out list))
            {
                list = new List<Message>();
                storage.Add(group, list);
            }

            list.Add(new Message(key, text, type));
        }

        public IEnumerable<Message> GetList(string key)
        {
            if (key == null)
                key = String.Empty;

            List<Message> list;
            if (!storage.TryGetValue(key, out list))
                return new List<Message>();

            return list;
        }

        public Dictionary<string, List<Message>> GetStorage()
        {
            return storage;
        }
    }
}

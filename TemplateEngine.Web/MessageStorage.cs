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

        public void Add(string key, string text, MessageType type = MessageType.Error)
        {
            if(key == null)
                key = String.Empty;

            List<Message> list;
            if (!storage.TryGetValue(key, out list))
            {
                list = new List<Message>();
                storage.Add(key, list);
            }

            list.Add(new Message(text, type));
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
    }
}

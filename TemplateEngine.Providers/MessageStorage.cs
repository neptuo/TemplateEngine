using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Providers
{
    /// <summary>
    /// List of messages.
    /// </summary>
    public class MessageStorage
    {
        private Dictionary<string, List<Message>> storage = new Dictionary<string, List<Message>>();

        /// <summary>
        /// Adds message with <paramref name="key"/> to <paramref name="group"/>.
        /// </summary>
        /// <param name="group">Messsage group.</param>
        /// <param name="key">Message key.</param>
        /// <param name="text">Message text.</param>
        /// <param name="type">Message type.</param>
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

        /// <summary>
        /// Gets enumeration of message in group <paramref name="key"/>.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IEnumerable<Message> GetList(string key)
        {
            if (key == null)
                key = String.Empty;

            List<Message> list;
            if (!storage.TryGetValue(key, out list))
                return new List<Message>();

            return list;
        }

        /// <summary>
        /// Gets internal storage.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<Message>> GetStorage()
        {
            return storage;
        }
    }
}

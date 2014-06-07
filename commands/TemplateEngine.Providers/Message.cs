using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Providers
{
    /// <summary>
    /// Single message.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Message key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Message type.
        /// </summary>
        public MessageType Type { get; set; }

        /// <summary>
        /// Message text.
        /// </summary>
        public string Text { get; set; }

        public Message(string key, string text, MessageType type = MessageType.Error)
        {
            Guard.NotNull(text, "text");
            Key = key;
            Text = text;
            Type = type;
        }
    }

    /// <summary>
    /// Types of message.
    /// </summary>
    public enum MessageType
    {
        Error, Info, Warn
    }
}

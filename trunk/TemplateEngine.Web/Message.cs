using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class Message
    {
        public MessageType Type { get; set; }
        public string Text { get; set; }

        public Message(string text, MessageType type = MessageType.Error)
        {
            if (text == null)
                throw new ArgumentNullException("text");

            Text = text;
        }
    }

    public enum MessageType
    {
        Error, Info, Warn
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class PartialResponse
    {
        public MessageStorage Messages { get; set; }
        public string Navigation { get; set; }

        public PartialResponse(MessageStorage messages, string navigation)
        {
            Messages = messages;
            Navigation = navigation;
        }

        public PartialResponse(Dictionary<string, List<Message>> messages, string navigation)
        {
            Messages = new MessageStorage(messages);
            Navigation = navigation;
        }
    }
}
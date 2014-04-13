using Neptuo.TemplateEngine.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class ServerPartialResponse
    {
        public Dictionary<string, List<Message>> Messages { get; set; }
        public string Navigation { get; set; }

        public ServerPartialResponse(Dictionary<string, List<Message>> messages, string navigation)
        {
            Messages = messages;
            Navigation = navigation;
        }
    }
}

using Neptuo.TemplateEngine.Web;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    public class MessagePanelControl : HtmlControlBase
    {
        protected MessageStorage MessageStorage { get; private set; }

        public string Group { get; set; }
        public string Key { get; set; }

        public MessagePanelControl(IComponentManager componentManager, MessageStorage messageStorage)
            : base(componentManager, "ul")
        {
            MessageStorage = messageStorage;
        }

        public override void Render(IHtmlWriter writer)
        {
            IEnumerable<Message> messages = MessageStorage.GetList(Group).Where(m => Key == null || m.Key == Key);
            if (messages.Any())
            {
                writer
                    .Tag(TagName)
                    .Attribute("class", "message-list");

                RenderAttributes(writer);

                foreach (Message message in messages)
                {
                    string cssClass = null;
                    switch (message.Type)
                    {
                        case MessageType.Error:
                            cssClass = "message-error";
                            break;
                        case MessageType.Info:
                            cssClass = "message-info";
                            break;
                        case MessageType.Warn:
                            cssClass = "message-warn";
                            break;
                    }

                    writer
                        .Tag("li")
                        .Attribute("class", cssClass)
                        .Content(message.Text)
                        .CloseFullTag();
                }

                writer
                    .CloseFullTag();
            }
        }
    }
}

using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class MessagePanelControl : ControlBase
    {
        protected MessageStorage MessageStorage { get; private set; }

        public string Group { get; set; }
        public string Key { get; set; }

        public MessagePanelControl(IComponentManager componentManager, MessageStorage messageStorage)
            : base(componentManager)
        {
            MessageStorage = messageStorage;
        }

        public override void Render(IHtmlWriter writer)
        {
            IEnumerable<Message> messages = MessageStorage.GetList(Group);
            if (messages.Any())
            {
                writer
                    .Tag("ul");

                RenderAttributes(writer);

                foreach (Message message in messages)
                {
                    if (Key == null || message.Key == Key)
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
                }

                writer
                    .CloseFullTag();
            }
        }
    }
}

using Neptuo.TemplateEngine.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Providers
{
    /// <summary>
    /// Controller outcome.
    /// </summary>
    public class PartialResponse
    {
        /// <summary>
        /// List of messages.
        /// </summary>
        public MessageStorage Messages { get; set; }

        /// <summary>
        /// Navigation rule.
        /// </summary>
        public string Navigation { get; set; }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="messages">List of messages.</param>
        /// <param name="navigation">Navigation rule.</param>
        public PartialResponse(MessageStorage messages, string navigation)
        {
            Messages = messages;
            Navigation = navigation;
        }
    }
}
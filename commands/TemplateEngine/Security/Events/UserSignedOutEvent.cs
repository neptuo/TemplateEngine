using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Security.Events
{
    /// <summary>
    /// Event fires when user is signed out.
    /// </summary>
    public class UserSignedOutEvent
    {
        /// <summary>
        /// Sign out timestmap.
        /// </summary>
        public DateTime Timestamp { get; private set; }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="timestamp">Sign out timestmap.</param>
        public UserSignedOutEvent(DateTime timestamp)
        {
            Timestamp = timestamp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Security.Events
{
    /// <summary>
    /// Event fired when user is signed in.
    /// </summary>
    public class UserSignedInEvent
    {
        /// <summary>
        /// User context.
        /// </summary>
        public IUserContext UserContext { get; private set; }

        /// <summary>
        /// Sign in timestamp.
        /// </summary>
        public DateTime Timestamp { get; private set; }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userContext">User context.</param>
        /// <param name="timestamp">Sign in timestamp.</param>
        public UserSignedInEvent(IUserContext userContext, DateTime timestamp)
        {
            Guard.NotNull(userContext, "userContext");
            UserContext = userContext;
            Timestamp = timestamp;
        }
    }
}

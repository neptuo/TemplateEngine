using Neptuo.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controllers
{
    public static class MessageStorageExtensions
    {
        public static void AddValidationResult(this MessageStorage messageStorage, IValidationResult validationResult, string group, bool addFillAll = true)
        {
            if (!validationResult.IsValid)
            {
                if (addFillAll)
                    messageStorage.Add(group, String.Empty, "Please fill all required values correctly.");

                foreach (IValidationMessage message in validationResult.Messages)
                    messageStorage.Add(group, message.Key, message.Message, MessageType.Error);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neptuo.ComponentModel.Converters;
using SharpKit.JavaScript;

namespace Neptuo.TemplateEngine.Accounts
{
    public class UserLogListResultConverter : ConverterBase<JsObject, UserLogListResult>
    {
        public override bool TryConvert(JsObject sourceValue, out UserLogListResult targetValue)
        {
            int totalCount = sourceValue["TotalCount"].As<int>();
            JsObject data = sourceValue["Data"].As<JsObject>();

            targetValue = new UserLogListResult(GetLogs(data), totalCount);
            return true;
        }

        private IEnumerable<UserLogViewModel> GetLogs(JsObject sourceValue)
        {
            List<UserLogViewModel> result = new List<UserLogViewModel>();

            JsArray array = sourceValue.As<JsArray>();
            for (int i = 0; i < array.length; i++)
            {
                JsObject item = array[i].As<JsObject>();
                result.Add(GetLog(item));
            }

            return result;
        }

        private UserLogViewModel GetLog(JsObject sourceValue)
        {
            return new UserLogViewModel(
                sourceValue["Key"].As<string>(),
                GetAccount(sourceValue["User"].As<JsObject>()),
                sourceValue["SignedIn"].As<DateTime>(),
                sourceValue["SignedOut"].As<DateTime?>(),
                sourceValue["LastActivity"].As<DateTime?>(),
                sourceValue["IsCurrent"].As<bool>()
            );
        }

        private UserAccountRowViewModel GetAccount(JsObject sourceValue)
        {
            return new UserAccountRowViewModel(sourceValue["Key"].As<int>(), sourceValue["Username"].As<string>());
        }
    }
}

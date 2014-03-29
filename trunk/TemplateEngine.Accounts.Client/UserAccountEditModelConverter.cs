using Neptuo.ComponentModel.Converters;
using SharpKit.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class UserAccountEditModelConverter : ConverterBase<JsObject, UserAccountEditModel>
    {
        public bool TryConvert(JsObject sourceValue, out UserAccountEditModel targetValue)
        {
            targetValue = new UserAccountEditModel();
            targetValue.Key = sourceValue["Key"].As<int>();
            targetValue.Username = sourceValue["Username"].As<string>();
            targetValue.Password = sourceValue["Password"].As<string>();
            targetValue.PasswordAgain = sourceValue["PasswordAgain"].As<string>();
            targetValue.IsEnabled = sourceValue["IsEnabled"].As<bool>();
            targetValue.RoleKeys = new List<int>(sourceValue["RoleKeys"].As<int[]>());
            return true;
        }
    }
}

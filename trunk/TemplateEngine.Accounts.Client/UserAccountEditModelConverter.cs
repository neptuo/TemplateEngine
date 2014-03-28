using Neptuo.ComponentModel.Converters;
using SharpKit.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class UserAccountEditModelConverter : IConverter<JsObject, UserAccountEditModel>
    {
        public bool TryConvert(JsObject sourceValue, out UserAccountEditModel targetValue)
        {
            targetValue = new UserAccountEditModel();
            targetValue.Username = sourceValue["Username"].As<string>();
            targetValue.Password = sourceValue["Password"].As<string>();
            targetValue.PasswordAgain = sourceValue["PasswordAgain"].As<string>();
            targetValue.IsEnabled = sourceValue["IsEnabled"].As<bool>();
            targetValue.RoleKeys = sourceValue["RoleKeys"].As<int[]>();
            return true;
        }

        public bool TryConvertGeneral(Type sourceType, Type targetType, object sourceValue, out object targetValue)
        {
            UserAccountEditModel model;
            if (TryConvert((JsObject)sourceValue, out model))
            {
                targetValue = model;
                return true;
            }

            targetValue = null;
            return false;
        }
    }
}

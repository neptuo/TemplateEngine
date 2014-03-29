using Neptuo.ComponentModel.Converters;
using SharpKit.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class UserRoleEditModelConverter : ConverterBase<JsObject, UserRoleEditModel>
    {
        public override bool TryConvert(JsObject sourceValue, out UserRoleEditModel targetValue)
        {
            targetValue = new UserRoleEditModel();
            targetValue.Key = sourceValue["Key"].As<int>();
            targetValue.Name = sourceValue["Name"].As<string>();
            targetValue.Description = sourceValue["Description"].As<string>();
            return true;
        }
    }
}

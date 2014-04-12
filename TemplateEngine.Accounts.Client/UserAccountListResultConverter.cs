using Neptuo.ComponentModel.Converters;
using SharpKit.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class UserAccountListResultConverter : ConverterBase<JsObject, UserAccountListResult>
    {
        public override bool TryConvert(JsObject sourceValue, out UserAccountListResult targetValue)
        {
            int totalCount = sourceValue["TotalCount"].As<int>();
            JsObject data = sourceValue["Data"].As<JsObject>();

            targetValue = new UserAccountListResult(GetAccounts(data), totalCount);
            return true;
        }

        private IEnumerable<UserAccountViewModel> GetAccounts(JsObject sourceValue)
        {
            List<UserAccountViewModel> data = new List<UserAccountViewModel>();

            JsArray array = sourceValue.As<JsArray>();
            for (int i = 0; i < array.length; i++)
            {
                JsObject item = array[i].As<JsObject>();

                data.Add(new UserAccountViewModel(
                    item["Key"].As<int>(),
                    item["Username"].As<string>(),
                    item["IsEnabled"].As<bool>(),
                    GetRoles(item)
                ));
            }

            return data;
        }

        private IEnumerable<UserRoleRowViewModel> GetRoles(JsObject item)
        {
            List<UserRoleRowViewModel> roles = new List<UserRoleRowViewModel>();
            JsArray rolesArray = item["Roles"].As<JsArray>();

            for (int i = 0; i < rolesArray.length; i++)
            {
                JsObject roleItem = rolesArray[i].As<JsObject>();
                roles.Add(new UserRoleRowViewModel(
                    roleItem["Key"].As<int>(),
                    roleItem["Name"].As<string>()
                ));
            }

            return roles;
        }
    }
}

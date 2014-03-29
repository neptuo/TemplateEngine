using Neptuo.ComponentModel.Converters;
using SharpKit.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class UserRoleListResultConverter : ConverterBase<JsObject, UserRoleListResult>
    {
        public override bool TryConvert(JsObject sourceValue, out UserRoleListResult targetValue)
        {
            int totalCount = sourceValue["TotalCount"].As<int>();
            JsObject data = sourceValue["Data"].As<JsObject>();

            targetValue = new UserRoleListResult(GetRoles(data), totalCount);
            return true;
        }

        private IEnumerable<UserRoleViewModel> GetRoles(JsObject sourceValue)
        {
            List<UserRoleViewModel> data = new List<UserRoleViewModel>();

            JsArray array = sourceValue.As<JsArray>();
            for (int i = 0; i < array.length; i++)
            {
                JsObject item = array[i].As<JsObject>();

                data.Add(new UserRoleViewModel(
                    item["Key"].As<int>(),
                    item["Name"].As<string>(),
                    item["Description"].As<string>()
                ));
            }

            return data;
        }

    }
}

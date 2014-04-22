using Neptuo.ComponentModel.Converters;
using Neptuo.TemplateEngine.Accounts.ViewModels;
using SharpKit.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class ResourcePermissionListResultConverter : ConverterBase<JsObject, ResourcePermissionListResult>
    {
        public override bool TryConvert(JsObject sourceValue, out ResourcePermissionListResult targetValue)
        {
            int totalCount = sourceValue["TotalCount"].As<int>();
            JsObject data = sourceValue["Data"].As<JsObject>();

            targetValue = new ResourcePermissionListResult(GetResourcePermissions(data), totalCount);
            return true;
        }

        private IEnumerable<ResourcePermissionEditViewModel> GetResourcePermissions(JsObject sourceValue)
        {
            List<ResourcePermissionEditViewModel> data = new List<ResourcePermissionEditViewModel>();

            JsArray array = sourceValue.As<JsArray>();
            for (int i = 0; i < array.length; i++)
            {
                JsObject item = array[i].As<JsObject>();

                data.Add(new ResourcePermissionEditViewModel(
                    item["ResourceName"].As<string>(),
                    item["ResourceHint"].As<string>(),
                    GetPermissionNames(item["Permissions"].As<JsArray>())
                ));
            }

            return data;
        }

        private IEnumerable<PermissionNameEditViewModel> GetPermissionNames(JsArray sourceValue)
        {
            List<PermissionNameEditViewModel> data = new List<PermissionNameEditViewModel>();
            
            JsArray array = sourceValue.As<JsArray>();
            for (int i = 0; i < array.length; i++)
            {
                JsObject item = array[i].As<JsObject>();

                data.Add(new PermissionNameEditViewModel(
                    item["RessourceName"].As<string>(),
                    item["PermissionName"].As<string>(),
                    item["IsEnabled"].As<bool>()
                ));
            }

            return data;
        }
    }
}

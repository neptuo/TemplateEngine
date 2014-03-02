using Neptuo.PresentationModels;
using Neptuo.PresentationModels.TypeModels;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Web.Controllers.Binders;
using Neptuo.TemplateEngine.Web.DataSources;
using SharpKit.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Web.DataSources
{
    public class UserAccountEditDataSource : IDataSource
    {
        private UserRepository userAccounts;
        private IModelValueProviderFactory providerFactory;
        private IModelBinder modelBinder;

        public int Key { get; set; }

        public UserAccountEditDataSource(UserRepository userAccounts, IModelValueProviderFactory providerFactory, IModelBinder modelBinder)
        {
            Guard.NotNull(userAccounts, "userAccounts");
            Guard.NotNull(providerFactory, "providerFactory");
            Guard.NotNull(modelBinder, "modelBinder");
            this.userAccounts = userAccounts;
            this.providerFactory = providerFactory;
            this.modelBinder = modelBinder;
        }

        public void GetItem(Action<object> callback)
        {
            if (Key == 0)
            {
                UserAccountEditModel model = new UserAccountEditModel { Key = 0, IsEnabled = true };
                model = modelBinder.Bind<UserAccountEditModel>(model);

                callback(providerFactory.Create(model));
                return;
            }

            HtmlContext.setTimeout(() =>
            {
                UserAccountEditModel model = userAccounts.GetAll().FirstOrDefault(u => u.Key == Key);
                model = modelBinder.Bind<UserAccountEditModel>(model);

                callback(providerFactory.Create(model));
            }, 400);
        }
    }
}

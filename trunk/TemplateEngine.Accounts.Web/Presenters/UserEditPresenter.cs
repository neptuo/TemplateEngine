using Neptuo.Commands;
using Neptuo.PresentationModels;
using Neptuo.PresentationModels.TypeModels;
using Neptuo.TemplateEngine.Accounts.Commands;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Accounts.Web.Controllers;
using Neptuo.TemplateEngine.Navigation;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Web.Controls;
using Neptuo.TemplateEngine.Web.Controls.DesignData;
using Neptuo.Templates;
using Neptuo.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Web.Presenters
{
    [Html("form")]
    [SupportUiEvent("UserEdit-Save", typeof(UserEditSaveController))]
    public class UserEditPresenter : PresentationControlBase
    {
        protected IUserAccountRepository UserAccounts { get; private set; }
        protected INavigator Navigator { get; private set; }
        protected IModelValueProviderFactory ValueProviderFactory { get; private set; }
        
        [PropertySet(true)]
        public int? UserKey { get; set; }

        public UserEditPresenter(
            IComponentManager componentManager, 
            PresentationConfiguration<EditUserCommand> configuration, 
            IUserAccountRepository userAccounts,
            INavigator navigator
        )
            : base(componentManager, configuration)
        {
            UserAccounts = userAccounts;
            Navigator = navigator;
            ValueProviderFactory = configuration.ValueProviderFactory;
            Attributes["method"] = "post";
            Attributes["action"] = "";
        }

        protected override IModelValueGetter CreateModel()
        {
            UserAccount userAccount;
            if (UserKey != null)
                userAccount = UserAccounts.Get(UserKey.Value) ?? UserAccounts.Create();
            else
                userAccount = UserAccounts.Create();

            EditUserCommand model = new EditUserCommand(userAccount);
            return ValueProviderFactory.Create(model);
        }
    }
}

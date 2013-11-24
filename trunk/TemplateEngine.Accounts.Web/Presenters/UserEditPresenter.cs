using Neptuo.Commands;
using Neptuo.PresentationModels;
using Neptuo.PresentationModels.TypeModels;
using Neptuo.TemplateEngine.Accounts.Commands;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Accounts.Queries;
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
    [SupportUiEvent("User/Save", typeof(UserEditSaveController))]
    public class UserEditPresenter : PresentationControlBase
    {
        protected IUserAccountQuery UserQuery { get; private set; }
        protected INavigator Navigator { get; private set; }
        protected IModelValueProviderFactory ValueProviderFactory { get; private set; }
        
        [PropertySet(true)]
        public int? UserKey { get; set; }

        public UserEditPresenter(
            IComponentManager componentManager, 
            PresentationConfiguration<EditUserCommand> configuration,
            IUserAccountQuery userQuery,
            INavigator navigator
        )
            : base(componentManager, configuration)
        {
            UserQuery = userQuery;
            Navigator = navigator;
            ValueProviderFactory = configuration.ValueProviderFactory;
        }

        protected override IModelValueGetter CreateModel()
        {
            UserAccount userAccount = null;
            if (UserKey != null)
                userAccount = UserQuery.Get(UserKey.Value);

            EditUserCommand model = new EditUserCommand(userAccount);
            return ValueProviderFactory.Create(model);
        }
    }
}

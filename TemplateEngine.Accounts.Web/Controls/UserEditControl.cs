using Neptuo.Data.Commands;
using Neptuo.PresentationModels.TypeModels;
using Neptuo.TemplateEngine.Accounts.Commands;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Web.Controls;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Web.Controls
{
    [Html("form")]
    public class UserEditControl : PresentationControlBase
    {
        protected IUserAccountRepository UserAccounts { get; private set; }
        protected EditUserCommand Model { get; private set; }
        protected IEventHandler EventHandler { get; private set; }
        protected ICommandDispatcher CommandDispatcher { get; private set; }
        public int? UserKey { get; set; }

        public UserEditControl(IComponentManager componentManager, PresentationConfiguration<EditUserCommand> configuration, IEventHandler eventHandler, ICommandDispatcher commandDispatcher, IUserAccountRepository userAccounts)
            : base(componentManager, configuration)
        {
            UserAccounts = userAccounts;
            EventHandler = eventHandler;
            CommandDispatcher = commandDispatcher;
            Attributes["method"] = "post";
            Attributes["action"] = "";
        }

        public override void OnInit()
        {
            EventHandler.Subscribe("Save", HandleSave);

            UserAccount userAccount;
            if (UserKey != null)
                userAccount = UserAccounts.Get(UserKey.Value) ?? UserAccounts.Create();
            else
                userAccount = UserAccounts.Create();

            Model = new EditUserCommand(userAccount);

            base.OnInit();
            Init(Template);

            ModelPresenter.SetData(new ReflectionModelValueProvider(Model));
        }

        protected void HandleSave(EventHandlerEventArgs e)
        {
            ModelPresenter.GetData(new ReflectionModelValueProvider(Model));

            if (Model.Password == Model.PasswordAgain)
                CommandDispatcher.Handle(Model);
        }
    }
}

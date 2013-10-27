using Neptuo.Data.Commands;
using Neptuo.Data.Commands.Validation;
using Neptuo.PresentationModels.TypeModels;
using Neptuo.TemplateEngine.Accounts.Commands;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Navigation;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Web.Controls;
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
    public class UserEditPresenter : PresentationControlBase
    {
        protected IUserAccountRepository UserAccounts { get; private set; }
        protected EditUserCommand Model { get; private set; }
        protected IEventHandler EventHandler { get; private set; }
        protected ICommandDispatcher CommandDispatcher { get; private set; }
        protected MessageStorage MessageStorage { get; private set; }
        protected INavigator Navigator { get; private set; }
        
        [PropertySet(true)]
        public int? UserKey { get; set; }

        public UserEditPresenter(
            IComponentManager componentManager, 
            PresentationConfiguration<EditUserCommand> configuration, 
            IEventHandler eventHandler, 
            ICommandDispatcher commandDispatcher, 
            IUserAccountRepository userAccounts,
            MessageStorage messageStorage,
            INavigator navigator
        )
            : base(componentManager, configuration)
        {
            UserAccounts = userAccounts;
            EventHandler = eventHandler;
            CommandDispatcher = commandDispatcher;
            MessageStorage = messageStorage;
            Navigator = navigator;
            Attributes["method"] = "post";
            Attributes["action"] = "";
        }

        public override void OnInit()
        {
            EventHandler.Subscribe("UserEdit-Save", HandleSave);

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

            IValidationResult validation = CommandDispatcher.Validate(Model);
            if (validation.IsValid)
            {
                CommandDispatcher.Handle(Model);
                MessageStorage.Add(null, "User account saved.", MessageType.Info);
                Navigator.Open((FormUri)"Accounts.User.List");
            }
            else
            {
                AddModelState(validation);
            }
        }

        protected void AddModelState(IValidationResult validation)
        {
            foreach (IValidationMessage message in validation.Messages)
                MessageStorage.Add(null, message.Message, MessageType.Error);
        }
    }
}

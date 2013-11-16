﻿using Neptuo.Commands;
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
        //protected EditUserCommand Model { get; private set; }
        //protected ICommandDispatcher CommandDispatcher { get; private set; }
        //protected MessageStorage MessageStorage { get; private set; }
        protected INavigator Navigator { get; private set; }
        protected IModelValueProviderFactory ValueProviderFactory { get; private set; }
        //protected DataContextStorage DataContext { get; private set; }
        
        [PropertySet(true)]
        public int? UserKey { get; set; }

        public UserEditPresenter(
            IComponentManager componentManager, 
            PresentationConfiguration<EditUserCommand> configuration, 
            //ICommandDispatcher commandDispatcher, 
            IUserAccountRepository userAccounts,
            //MessageStorage messageStorage,
            INavigator navigator
        )
            : base(componentManager, configuration)
        {
            UserAccounts = userAccounts;
            //CommandDispatcher = commandDispatcher;
            //MessageStorage = messageStorage;
            Navigator = navigator;
            ValueProviderFactory = configuration.ValueProviderFactory;
            //DataContext = configuration.DataContext;
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

        //public override void OnInit()
        //{
        //    UserAccount userAccount;
        //    if (UserKey != null)
        //        userAccount = UserAccounts.Get(UserKey.Value) ?? UserAccounts.Create();
        //    else
        //        userAccount = UserAccounts.Create();

        //    Model = new EditUserCommand(userAccount);

        //    IModelValueProvider provider = ValueProviderFactory.Create(Model);
        //    DataContext.Push(provider);

        //    base.OnInit();
        //    Init(Template);

        //    DataContext.Pop();
        //}

        //[Obsolete]
        //protected void HandleSave()
        //{
        //    ModelPresenter.GetData(ValueProviderFactory.Create(Model));

        //    IValidationResult validation = CommandDispatcher.Validate(Model);
        //    if (validation.IsValid)
        //    {
        //        CommandDispatcher.Handle(Model);
        //        MessageStorage.Add(null, String.Empty, "User account saved.", MessageType.Info);
        //        Navigator.Open((FormUri)"Accounts.User.List");
        //    }
        //    else
        //    {
        //        AddModelState(validation);
        //    }
        //}

        //protected void AddModelState(IValidationResult validation)
        //{
        //    foreach (IValidationMessage message in validation.Messages)
        //        MessageStorage.Add(null, message.Key, message.Message, MessageType.Error);
        //}
    }
}

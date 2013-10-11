using Neptuo.PresentationModels.TypeModels;
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
        protected UserAccount UserAccount { get; private set; }
        protected IEventHandler EventHandler { get; private set; }
        public int? UserKey { get; set; }

        public UserEditControl(IComponentManager componentManager, IStackStorage<IViewStorage> viewStorage, IEventHandler eventHandler, IUserAccountRepository userAccounts)
            : base(componentManager, new ReflectionModelDefinitionBuilder(typeof(UserAccount), new MetadataReaderService()).Build(), viewStorage)
        {
            UserAccounts = userAccounts;
            EventHandler = eventHandler;
            Attributes["method"] = "post";
            Attributes["action"] = "";
        }

        public override void OnInit()
        {
            EventHandler.Subscribe("Save", HandleSave);

            if (UserKey != null)
                UserAccount = UserAccounts.Get(UserKey.Value) ?? UserAccounts.Create();
            else
                UserAccount = UserAccounts.Create();

            UserAccount.Username = "Pepa";
            UserAccount.Password = "ABc";

            base.OnInit();

            ModelPresenter.SetData(new ReflectionModelValueProvider(UserAccount));
        }

        protected void HandleSave(EventHandlerEventArgs e)
        {
            ModelPresenter.GetData(new ReflectionModelValueProvider(UserAccount));
        }
    }
}

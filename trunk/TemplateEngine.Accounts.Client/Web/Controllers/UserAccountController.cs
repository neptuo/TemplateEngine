using Neptuo.TemplateEngine.Accounts.Commands;
using Neptuo.TemplateEngine.Controllers;
using Neptuo.TemplateEngine.Providers.ModelBinders;
using SharpKit.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Web.Controllers
{
    public class UserAccountController : IController
    {
        public IControllerContext Context { get; private set; }

        [Action("Accounts/User/Create")]
        public void Create()
        {
            UserAccountCreateCommand model = Context.ModelBinder.Bind<UserAccountCreateCommand>(new UserAccountCreateCommand());
            HtmlContext.console.log(model);
        }

        public void Execute(IControllerContext context)
        {
            Context = context;
            Create();
        }
    }
}

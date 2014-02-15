using Neptuo.TemplateEngine.Web.Controllers;
using Neptuo.TemplateEngine.Web.Controllers.Binders;
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
            EditUserCommand model = Context.ModelBinder.Bind<EditUserCommand>(new EditUserCommand());
            HtmlContext.console.log(model);
        }

        public void Execute(IControllerContext context)
        {
            Context = context;
            Create();
        }
    }
}

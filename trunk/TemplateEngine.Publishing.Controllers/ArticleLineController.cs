using Neptuo.TemplateEngine.Controllers;
using Neptuo.TemplateEngine.Publishing.Controllers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.Controllers
{
    public class ArticleLineController : ControllerBase
    {
        [Action("Publishing/ArticleLine/Create")]
        public string Create(ArticleLineCreateCommand model)
        {


            return null;
        }

        [Action("Publishing/ArticleLine/Update")]
        public string Create(ArticleLineEditCommand model)
        {


            return null;
        }
    }
}

using Neptuo.PresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class DefaultModelPresenter : ModelPresenterBase
    {
        public DefaultModelPresenter(IModelDefinition modelDefinition, IModelView modelView)
        {
            SetModel(modelDefinition);
            SetView(modelView);
            Prepare();
        }

        public override void Prepare()
        { }
    }
}

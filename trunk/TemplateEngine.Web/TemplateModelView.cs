using Neptuo.PresentationModels;
using Neptuo.TemplateEngine.Web.Controls;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class TemplateModelView : ModelViewBase
    {
        public IComponentManager ComponentManager { get; private set; }
        public ITemplateContent Template { get; set; }
        protected IStackStorage<IViewStorage> ViewStorage { get; private set; }
        public IViewStorage Storage { get; private set; }

        public TemplateModelView(IComponentManager componentManager, IStackStorage<IViewStorage> viewStorage)
        {
            if (componentManager == null)
                throw new ArgumentNullException("componentManager");

            if (viewStorage == null)
                throw new ArgumentNullException("viewStorage");

            ComponentManager = componentManager;
            ViewStorage = viewStorage;
            Storage = new DictionaryViewStorage();
        }

        public void OnInit(Action innerInit)
        {
            if (innerInit != null)
            {
                ViewStorage.Push(Storage);
                innerInit();
                ViewStorage.Pop();
            }
        }

        protected override IFieldView GetFieldViewByIdentifier(string identifier)
        {
            return Storage[identifier];
        }
    }
}

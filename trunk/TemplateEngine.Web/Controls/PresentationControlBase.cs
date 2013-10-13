using Neptuo.PresentationModels;
using Neptuo.PresentationModels.TypeModels;
using Neptuo.TemplateEngine.Web.Controls;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    [DefaultProperty("Template")]
    public class PresentationControlBase : ControlBase
    {
        //public ITemplate Template { get; set; }
        public IModelDefinition ModelDefinition { get; private set; }
        public ITemplate Template { get; set; }

        protected ITemplateContent TemplateContent { get; private set; }
        protected IModelPresenter ModelPresenter { get; private set; }
        protected TemplateModelView ModelView { get; private set; }

        public PresentationControlBase(IComponentManager componentManager, PresentationConfiguration configuration)
            : base(componentManager)
        {
            ModelView = new TemplateModelView(ComponentManager, configuration.ViewStorage);
            ModelDefinition = new FilteredModelDefinition(configuration.ModelDefinition, ModelView);
            ModelPresenter = new DefaultModelPresenter(ModelDefinition, ModelView);
        }

        public override void OnInit()
        {
            Init(Template);
            TemplateContent = Template.CreateInstance();
            //Init(TemplateContent);
            ModelView.Template = TemplateContent;
            ModelView.OnInit();
        }

        protected override void RenderBody(IHtmlWriter writer)
        {
            Render(TemplateContent, writer);
        }

        public void SetData(IModelValueGetter getter)
        {
            ModelPresenter.SetData(getter);
        }

        public void GetData(IModelValueSetter setter)
        {
            ModelPresenter.GetData(setter);
        }
    }

    public class PresentationConfiguration
    {
        public IModelDefinition ModelDefinition { get; protected set; }
        public IStackStorage<IViewStorage> ViewStorage { get; protected set; }

        public PresentationConfiguration(IModelDefinition modelDefinition, IStackStorage<IViewStorage> viewStorage)
        {
            if(modelDefinition == null)
                throw new ArgumentNullException("modelDefinition");

            if(viewStorage == null)
                throw new ArgumentNullException("viewStorage");

            ModelDefinition = modelDefinition;
            ViewStorage = viewStorage;
        }
    }

    public class PresentationConfiguration<T> : PresentationConfiguration
    {
        public PresentationConfiguration(MetadataReaderService metadataReaderService, IStackStorage<IViewStorage> viewStorage)
            : base(new ReflectionModelDefinitionBuilder(typeof(T), metadataReaderService).Build(), viewStorage)
        { }
    }

    public class FilteredModelDefinition : ProxyModelDefinition
    {
        private TemplateModelView modelView;

        public FilteredModelDefinition(IModelDefinition modelDefinition, TemplateModelView modelView)
            : base(modelDefinition)
        {
            this.modelView = modelView;
        }

        protected override IEnumerable<IFieldDefinition> RefreshFields()
        {
            List<IFieldDefinition> fields = new List<IFieldDefinition>();
            foreach (IFieldDefinition field in ModelDefinition.Fields)
            {
                if (modelView.Storage[field.Identifier] != null)
                    fields.Add(field);
            }
            return fields;
        }
    }

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

            //if (content == null)
            //    throw new ArgumentNullException("content");

            ComponentManager = componentManager;
            ViewStorage = viewStorage;
            Storage = new DictionaryViewStorage();
            //Content = content;
        }

        public void OnInit()
        {
            if (Template != null)
            {
                ViewStorage.Push(Storage);
                ComponentManager.Init(Template);
                ViewStorage.Pop();
            }
        }

        protected override IFieldView GetFieldViewByIdentifier(string identifier)
        {
            return Storage[identifier];
        }
    }

    public class DictionaryViewStorage : IViewStorage
    {
        private Dictionary<string, IFieldView> storage = new Dictionary<string, IFieldView>();

        public IFieldView this[string identifier]
        {
            get
            {
                IFieldView fieldView;
                if (storage.TryGetValue(identifier, out fieldView))
                    return fieldView;

                return null;
            }
            set { storage[identifier] = value; }
        }
    }

}

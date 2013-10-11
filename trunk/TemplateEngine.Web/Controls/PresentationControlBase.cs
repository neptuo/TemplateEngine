﻿using Neptuo.PresentationModels;
using Neptuo.TemplateEngine.Web.Controls;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class PresentationControlBase : BaseContentControl
    {
        //public ITemplate Template { get; set; }
        public IModelDefinition ModelDefinition { get; private set; }
        protected IModelPresenter ModelPresenter { get; private set; }
        protected TemplateModelView ModelView { get; private set; }

        public PresentationControlBase(IComponentManager componentManager, IModelDefinition modelDefinition, IStackStorage<IViewStorage> viewStorage)
            : base(componentManager)
        {
            ModelView = new TemplateModelView(ComponentManager, viewStorage);
            ModelDefinition = new FilteredModelDefinition(modelDefinition, ModelView);
            ModelPresenter = new DefaultModelPresenter(ModelDefinition, ModelView);
        }

        public override void OnInit()
        {
            ModelView.Content = Content;
            ModelView.OnInit();
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
                if (modelView.Storage[field.Identifier].GetType() != typeof(GreedyFieldView))
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
        public ICollection<object> Content { get; set; }
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
            if (Content != null)
            {
                ViewStorage.Push(Storage);

                foreach (object item in Content)
                    ComponentManager.Init(item);
                
                ViewStorage.Pop();
            }
        }

        protected override IFieldView GetFieldViewByIdentifier(string identifier)
        {
            return Storage[identifier];
        }
    }

    public class GreedyFieldView : IFieldView
    {
        public object GetValue()
        {
            return null;
        }

        public void SetValue(object value)
        { }
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

                return new GreedyFieldView();
            }
            set { storage[identifier] = value; }
        }
    }

}

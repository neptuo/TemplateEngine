﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;
using Neptuo.Templates;
using Neptuo.Templates.Controls;
using Neptuo.Reflection;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Controls extends this class support tag name specified in <see cref="ComponentAttribute"/>.
    /// </summary>
    public abstract class ControlBase : IControl
    {
        private string defaultPropertyName;

        protected IComponentManager ComponentManager { get; private set; }
        protected string DefaultPropertyName
        {
            get
            {
                if (defaultPropertyName == null)
                {
                    DefaultPropertyAttribute attr = ReflectionHelper.GetAttribute<DefaultPropertyAttribute>(GetType());
                    if (attr != null)
                        defaultPropertyName = attr.Name;
                }
                return defaultPropertyName;
            }
            set { defaultPropertyName = value; }
        }

        public ControlBase(IComponentManager componentManager)
        {
            ComponentManager = componentManager;
        }

        public virtual void OnInit() { }

        public virtual void Render(IHtmlWriter writer) { }

        protected void InitComponent(object component)
        {
            ComponentManager.Init(component);
        }

        protected void RenderComponent(object component, IHtmlWriter writer)
        {
            ComponentManager.Render(component, writer);
        }

        protected void InitComponents<T>(IEnumerable<T> compoments)
        {
            if (compoments != null)
            {
                foreach (T component in compoments)
                    InitComponent(component);
            }
        }
    }
}

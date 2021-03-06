﻿using Neptuo.Templates;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Collections;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Base of content html control.
    /// </summary>
    [DefaultProperty("Content")]
    public abstract class HtmlContentControlBase : HtmlControlBase, IContentControl
    {
        protected override bool IsSelfClosing
        {
            get
            {
                if (Content != null && Content.Count != 0)
                    return false;

                return base.IsSelfClosing;
            }
        }

        public ICollection<object> Content { get; set; }

        public HtmlContentControlBase(IComponentManager componentManager, string tagName, bool isSelfClosing = false)
            : base(componentManager, tagName, isSelfClosing)
        { }

        public override void OnInit()
        {
            base.OnInit();

            if (Content != null)
            {
                foreach (object item in Content)
                    ComponentManager.Init(item);
            }
        }

        protected override void RenderBody(IHtmlWriter writer)
        {
            if (Content != null)
            {
                foreach (object item in Content)
                    ComponentManager.Render(item, writer);
            }
        }
    }
}

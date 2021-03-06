﻿using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Creates button.
    /// </summary>
    public class ButtonControl : HtmlContentControlBase
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public ButtonControl(IComponentManager componentManager)
            : base(componentManager, "button")
        {
            Attributes["class"] = "btn";
        }

        public override void OnInit()
        {
            base.OnInit();

            if (!String.IsNullOrEmpty(Name))
                Attributes["name"] = Name;

            if (Content == null)
            {
                Content = new List<object>();
                Content.Add(Text);
            }
        }
    }
}

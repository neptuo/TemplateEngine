﻿using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Creates checkbox.
    /// </summary>
    public class CheckBoxControl : FormInputControlBase
    {
        public string LabelText { get; set; }
        public string Value { get; set; }
        public bool IsChecked { get; set; }

        public CheckBoxControl(IComponentManager componentManager)
            : base(componentManager)
        {
            Type = "checkbox";
        }

        public override void Render(IHtmlWriter writer)
        {
            if (IsChecked)
                Attributes["checked"] = "checked";

            if (Value != null)
                Attributes["value"] = Value;

            writer
                .Tag("label")
                .Attribute("class", "checkbox");

            base.Render(writer);

            writer
                .Content(LabelText)
                .CloseFullTag();
        }
    }
}

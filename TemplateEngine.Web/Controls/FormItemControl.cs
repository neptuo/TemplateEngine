﻿using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class FormItemControl : ContentControlBase
    {
        public string LabelText { get; set; }

        public FormItemControl(IComponentManager componentManager)
            : base(componentManager)
        { }

        public override void Render(IHtmlWriter writer)
        {
            writer
                .Tag("div")
                .Attribute("class", "control-group");

            foreach (KeyValuePair<string, string> attribute in Attributes)
                writer.Attribute(attribute.Key, attribute.Value);

            if (!String.IsNullOrEmpty(LabelText))
            {
                writer
                    .Tag("label")
                    .Attribute("class", "control-label")
                    .Content(LabelText)
                    .CloseFullTag();
            }

            writer
                .Tag("div")
                .Attribute("class", "controls");

            RenderBody(writer);

            writer
                .CloseFullTag();

            //if (!String.IsNullOrEmpty(LabelText))
            //{
            //    writer
            //        .CloseFullTag();
            //}

            writer
                .CloseFullTag();
        }
    }
}
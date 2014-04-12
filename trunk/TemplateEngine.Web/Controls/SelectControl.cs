using Neptuo.Templates;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class SelectControl : ListViewControl, IHtmlAttributeCollection, IAttributeCollection
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public bool IsAddEmpty { get; set; }
        public HtmlAttributeCollection Attributes { get; private set; }

        [DefaultValue("Key")]
        public string SelectedValuePath { get; set; }

        protected IBindingManager BindingManager { get; private set; }

        public SelectControl(SelectControlContext context)
            : base(context.RequestContext, context.Storage, context.DataContext)
        {
            Attributes = new HtmlAttributeCollection();
            BindingManager = context.BindingManager;
        }

        public void SetAttribute(string name, string value)
        {
            Attributes[name] = value;
        }

        public override void OnInit()
        {
            Guard.NotNullOrEmpty(SelectedValuePath, "SelectedValuePath");
            base.OnInit();
        }

        protected override void ProcessModelItem(List<object> itemTemplates, object model)
        {
            SelectItem item = new SelectItem(model);
            object targetSelectedValue;
            if (BindingManager.TryGetValue(SelectedValuePath, model, out targetSelectedValue))
                item.IsSelected = IsSelectedValue(targetSelectedValue);

            base.ProcessModelItem(itemTemplates, item);
        }

        protected virtual bool IsSelectedValue(object targetSelectedValue)
        {
            if (!(Value is string))
            {
                IEnumerable collection = Value as IEnumerable;
                if (collection != null)
                {
                    foreach (object item in collection)
                    {
                        if (IsSelectedSingleValue(item, targetSelectedValue))
                            return true;
                    }
                }
            }

            return IsSelectedSingleValue(Value, targetSelectedValue);
        }

        private bool IsSelectedSingleValue(object itemValue, object targetSelectedValue)
        {
            if (itemValue == null && targetSelectedValue == null)
                return true;

            if ((itemValue != null && targetSelectedValue == null) || (itemValue == null && targetSelectedValue != null))
                return false;

            if (itemValue.GetType() != targetSelectedValue.GetType())
            {
                object targetValue;
                if (Converts.Try(itemValue.GetType(), targetSelectedValue.GetType(), itemValue, out targetValue))
                {
                    if (Object.Equals(targetSelectedValue, targetValue))
                        return true;
                    else
                        return false;
                }
            }

            if (Object.Equals(itemValue, targetSelectedValue))
                return true;

            return false;
        }
    }
}

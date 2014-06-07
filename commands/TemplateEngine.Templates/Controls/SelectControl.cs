using Neptuo.Templates;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Control that processes models from <see cref="IListDataSource"/> and creates <see cref="SelectItem"/>
    /// including comparision with selected value.
    /// Each item is wrapped with <see cref="SelectItem"/> and <see cref="SelectItem.IsSelected"/> is set accordingly to <see cref="Value"/>.
    /// </summary>
    public class SelectControl : ListViewControl, IHtmlAttributeCollection, IAttributeCollection
    {
        public string Name { get; set; }

        /// <summary>
        /// Selected value (or collection of value).
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Add empty item to list model?
        /// </summary>
        public bool IsAddEmpty { get; set; }

        /// <summary>
        /// List of attributes.
        /// </summary>
        public HtmlAttributeCollection Attributes { get; private set; }

        /// <summary>
        /// Navigation property path in each item from data source to compare with selected value.
        /// </summary>
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

        /// <summary>
        /// Create <see cref="SelectItem"/> for model.
        /// </summary>
        protected override void ProcessModelItem(List<object> itemTemplates, object model)
        {
            SelectItem item = new SelectItem(model);
            object targetSelectedValue;
            if (BindingManager.TryGetValue(SelectedValuePath, model, out targetSelectedValue))
                item.IsSelected = IsSelectedValue(targetSelectedValue);

            base.ProcessModelItem(itemTemplates, item);
        }

        /// <summary>
        /// If <see cref="Value"/> is collection, enumerates on it.
        /// </summary>
        /// <param name="targetSelectedValue">Model item.</param>
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

        /// <summary>
        /// Tries to determine if <paramref name="targetSelectedValue"/> is equal to <paramref name="itemValue"/>.
        /// </summary>
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

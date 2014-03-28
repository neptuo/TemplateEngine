using Neptuo.Templates;
using System;
using System.Collections;
using System.Collections.Generic;
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

        public string SelectedValuePath { get; set; }

        protected IBindingManager BindingManager { get; private set; }

        public SelectControl(IRequestContext requestContext, TemplateContentStorageStack storage, DataContextStorage dataContext, PartialUpdateHelper updateHelper, IBindingManager bindingManager)
            : base(requestContext, storage, dataContext, updateHelper)
        {
            Guard.NotNull(bindingManager, "bindingManager");
            Attributes = new HtmlAttributeCollection();
            BindingManager = bindingManager;
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
            IEnumerable collection = Value as IEnumerable;
            if (collection != null)
            {
                foreach (object item in collection)
                {
                    if (Object.Equals(item, targetSelectedValue))
                        return true;
                }
            }

            return targetSelectedValue == Value;
        }
    }
}

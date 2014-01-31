using Neptuo.PresentationModels;
using Neptuo.Templates;
using Neptuo.Templates.Controls;
using Neptuo.Templates.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.PresentationModels.Observers
{
    public class ViewIdentifierObserver : IObserver, IFieldView
    {
        public string ID { get; set; }
        public IControl Control { get; set; }
        protected IStackStorage<IViewStorage> ViewStorage { get; private set; }

        public ViewIdentifierObserver(IStackStorage<IViewStorage> viewStorage)
        {
            if (viewStorage == null)
                throw new ArgumentNullException("viewStorage");

            ViewStorage = viewStorage;
        }

        public void OnInit(ObserverEventArgs e)
        {
            //IFormControl formControl = e.Target as IFormControl;
            //if (formControl != null && String.IsNullOrEmpty(formControl.Name))
            //    formControl.Name = ID;

            Control = e.Target;
            ViewStorage.Peek()[ID] = this;
        }

        public void Render(ObserverEventArgs e, IHtmlWriter writer)
        { }

        public object GetValue()
        {
            //ITextControl textControl = Control as ITextControl;
            //if (textControl != null)
            //    return textControl.Text;

            //CheckBoxControl checkBoxControl = Control as CheckBoxControl;
            //if (checkBoxControl != null)
            //    return checkBoxControl.IsChecked;

            return null;
        }

        public void SetValue(object value)
        {
            //ITextControl textControl = Control as ITextControl;
            //if (textControl != null)
            //{
            //    textControl.Text = String.Format("{0}", value);
            //    return;
            //}

            //IValueControl valueControl = Control as IValueControl;
            //if (valueControl != null)
            //{
            //    valueControl.Value = value;
            //    return;
            //}

            //CheckBoxControl checkBoxControl = Control as CheckBoxControl;
            //if (checkBoxControl != null)
            //{
            //    checkBoxControl.IsChecked = (bool)value;
            //    return;
            //}
        }
    }
}

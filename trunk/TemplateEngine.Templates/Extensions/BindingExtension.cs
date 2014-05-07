﻿using Neptuo.Templates.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Extensions
{
    [DefaultProperty("Expression")]
    public class BindingExtension : IValueExtension
    {
        protected DataContextStorage DataContext { get; private set; }
        protected IValueConverterService ConverterService { get; private set; }
        protected IBindingManager BindingManager { get; private set; }
        public string Expression { get; set; }
        public string ConverterKey { get; set; }

        public BindingExtension(DataContextStorage dataContext, IBindingManager bindingManager, IValueConverterService converterService)
        {
            DataContext = dataContext;
            BindingManager = bindingManager;
            ConverterService = converterService;
        }

        public object ProvideValue(IValueExtensionContext context)
        {
            object data = GetData();

            if (!String.IsNullOrEmpty(ConverterKey))
                data = ConverterService.GetConverter(ConverterKey).ConvertTo(data);

            return data;
        }

        protected virtual object GetData()
        {
            object source = DataContext.Peek();
            object value;
            if (BindingManager.TryGetValue(Expression, source, out value))
                return value;

            return null;
        }
    }
}
using Neptuo.PresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates
{
    public class BindingManagerBase : IBindingManager
    {
        public bool TrySetValue(object target, string expression, object value)
        {
            PropertyInfo info = null;
            Type type = target.GetType();
            string[] exprs = expression.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < exprs.Length; i++)
            {
                info = type.GetProperty(exprs[i]);
                type = info.PropertyType;

                if (i < (exprs.Length - 1))
                    target = info.GetValue(target, null);
            }

            if (info != null)
                info.SetValue(target, value, null);

            return info != null;
        }

        public bool TryGetValue(string expression, object source, out object value)
        {
            if (String.IsNullOrEmpty(expression))
            {
                value = source;
                return true;
            }

            if (source == null)
            {
                value = null;
                return false;
            }

            IModelValueProvider provider = source as IModelValueProvider;
            if (provider != null)
                return provider.TryGetValue(expression, out value);

            PropertyInfo info = null;
            Type type = source.GetType();
            string[] exprs = expression.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < exprs.Length; i++)
            {
                info = type.GetProperty(exprs[i]);
                if (info == null)
                {
                    value = null;
                    return false;
                }


                if (source != null)
                {
                    source = info.GetValue(source, null);
                    if (source != null)
                        type = source.GetType();
                    else
                        type = info.PropertyType;
                } 

                provider = source as IModelValueProvider;
                if (provider != null)
                    return provider.TryGetValue(String.Join(".", exprs.Skip(i + 1)), out value);
            }

            value = source;
            return true;
        }
    }
}

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
        public virtual bool TrySetValue(object target, string expression, object value)
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

        public virtual bool TryGetValue(string expression, object source, out object value)
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

            IModelValueGetter provider = source as IModelValueGetter;
            if (provider != null)
                return provider.TryGetValue(expression, out value);

            string[] exprs = expression.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            return TryGetValueInternal(exprs, 0, source, out value);
        }

        protected virtual bool TryGetValueInternal(string[] expression, int expressionIndex, object source, out object value)
        {
            if(expression.Length == expressionIndex)
            {
                value = source;
                return true;
            }

            if(source == null)
            {
                value = null;
                return true;
            }

            IModelValueGetter provider = source as IModelValueGetter;
            if (provider != null)
                return provider.TryGetValue(String.Join(".", expression.Skip(expressionIndex)), out value);

            Type type = source.GetType();
            PropertyInfo info = type.GetProperty(expression[expressionIndex]);
            if (info == null)
            {
                value = null;
                return false;
            }

            if (source != null)
                source = info.GetValue(source, null);

            return TryGetValueInternal(expression, expressionIndex + 1, source, out value);
        }
    }
}

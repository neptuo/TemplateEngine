using Neptuo.ComponentModel.Converters;
using SharpKit.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine
{
    public abstract class ReflectionConverterBase<TTarget> : ConverterBase<JsObject, TTarget>
        where TTarget: new()
    {
        public override bool TryConvert(JsObject sourceValue, out TTarget targetValue)
        {
            targetValue = BindInstance(sourceValue, new TTarget()).As<TTarget>();
            return true;
        }

        protected object BindInstance(JsObject sourceValue, object targetValue)
        {
            Guard.NotNull(targetValue, "targetValue");

            foreach (PropertyInfo propertyInfo in targetValue.GetType().GetProperties())
            {

                if (propertyInfo.CanWrite)
                {
                    if (typeof(IEnumerable<>).IsAssignableFrom(propertyInfo.PropertyType))
                        propertyInfo.SetValue(targetValue, new List<object>(sourceValue[propertyInfo.Name].As<object[]>()));
                    else if (typeof(DateTime).IsAssignableFrom(propertyInfo.PropertyType))
                        propertyInfo.SetValue(targetValue, DateTime.Parse(sourceValue[propertyInfo.Name].As<string>()));
                    else
                        propertyInfo.SetValue(targetValue, sourceValue[propertyInfo.Name]);
                }
            }

            return targetValue;
        }
    }
}

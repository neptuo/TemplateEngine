using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication20
{
    public interface IConfiguration
    {
        void MapProperty<T>();
        T GetProperty<T>() where T : IConfigurationProperty, new();
    }

    public interface IConfigurationProperty
    {
        string Name { get; }
        Type PropertyType { get; }
        IConfigurationPropertyScope Scope { get; }
    }

    public interface IConfigurationProperty<T> : IConfigurationProperty
    {
        T Value { get; }
    }

    public interface IUpdateableConfigurationProperty
    {
        void SetValue(string value);
    }

    #region Scope

    public interface IConfigurationPropertyScope
    {
        string GetValue(string key);
    }

    public class StaticConfigurationPropertyScope : IConfigurationPropertyScope
    {
        internal StaticConfigurationPropertyScope()
        { }

        public string GetValue(string key)
        {
            return "false";
        }
    }

    public class ApplicationConfigurationPropertyScope : IConfigurationPropertyScope
    {
        internal ApplicationConfigurationPropertyScope()
        { }

        public string GetValue(string key)
        {
            return "true";
        }
    }

    public class UserConfigurationPropertyScope : IConfigurationPropertyScope
    {
        internal UserConfigurationPropertyScope()
        { }

        public string GetValue(string key)
        {
            return "false";
        }
    }

    public class FormConfigurationPropertyScope : IConfigurationPropertyScope
    {
        internal FormConfigurationPropertyScope()
        { }

        public string GetValue(string key)
        {
            return "true";
        }
    }

    #endregion

    #region Implementation

    public static class ConfigurationScope
    {
        public static readonly StaticConfigurationPropertyScope Static = new StaticConfigurationPropertyScope();
        public static readonly ApplicationConfigurationPropertyScope Application = new ApplicationConfigurationPropertyScope();
        public static readonly UserConfigurationPropertyScope User = new UserConfigurationPropertyScope();
        public static readonly FormConfigurationPropertyScope Form = new FormConfigurationPropertyScope();
    }

    public class Configuration : IConfiguration
    {
        private IConfigurationPropertyScope DefaultScope = ConfigurationScope.Application;

        HashSet<Type> properties = new HashSet<Type>();

        public void MapProperty<T>()
        {
            properties.Add(typeof(T));
        }

        public T GetProperty<T>() where T : IConfigurationProperty, new()
        {
            if (properties.Contains(typeof(T)))
            {
                IConfigurationProperty property = new T();
                IUpdateableConfigurationProperty updateable = property as IUpdateableConfigurationProperty;
                if (updateable != null)
                {
                    string value = (property.Scope ?? DefaultScope).GetValue(property.Name);
                    updateable.SetValue(value); //TODO: Get from context using Scope.
                }

                return (T)property;
            }

            return new T();
        }
    }

    public abstract class ConfigurationProperty<T> : IConfigurationProperty<T>, IUpdateableConfigurationProperty
    {
        public string Name { get; protected set; }
        public Type PropertyType { get; protected set; }
        public IConfigurationPropertyScope Scope { get; protected set; }
        public T Value { get; protected set; }

        public ConfigurationProperty(T defaultValue, IConfigurationPropertyScope scope, string name = null)
        {
            PropertyType = typeof(T);
            Value = defaultValue;
            Scope = scope;
            Name = name ?? GetType().FullName;
        }

        public void SetValue(string value)
        {
            T target;
            if (TryParseValue(value, out target))
                Value = target;
        }

        protected abstract bool TryParseValue(string source, out T target);
    }

    public class BoolConfigurationProperty : ConfigurationProperty<bool>
    {
        public BoolConfigurationProperty(bool defaultValue, IConfigurationPropertyScope scope, string name = null)
            : base(defaultValue, scope, name)
        { }

        protected override bool TryParseValue(string source, out bool target)
        {
            return Boolean.TryParse(source, out target);
        }
    }


    #endregion

}

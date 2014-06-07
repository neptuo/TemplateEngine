using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.DataSources
{
    /// <summary>
    /// Overrides <see cref="SetParameters"/> and using reflection sets value of properties defined in ctor.
    /// </summary>
    /// <typeparam name="TResultModel"></typeparam>
    public class DynamicListDataSourceProxy<TResultModel> : ListDataSourceProxy<TResultModel>
        where TResultModel : IListResult
    {
        /// <summary>
        /// List of properties to append to request.
        /// </summary>
        private IEnumerable<string> properties;

        /// <param name="properties">List of properties to append to request.</param>
        public DynamicListDataSourceProxy(IVirtualUrlProvider urlProvider, IEnumerable<string> properties)
            : base(urlProvider)
        {
            Guard.NotNull(properties, "properties");
            this.properties = properties;
        }

        protected override void SetParameters(JsObjectBuilder parameterBuilder)
        {
            foreach (string propertyName in properties)
            {
                PropertyInfo propertyInfo = GetType().GetProperty(propertyName);
                object propertyValue = propertyInfo.GetValue(this, null);
                parameterBuilder.Set(propertyName, propertyValue);
            }
        }
    }
}

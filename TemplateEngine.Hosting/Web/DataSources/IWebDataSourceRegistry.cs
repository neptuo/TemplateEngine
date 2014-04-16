using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.DataSources
{
    public interface IWebDataSourceRegistry
    {
        void Add(string name, Type dataSourceType);

        bool TryGet(string name, out Type dataSourceType);
    }
}

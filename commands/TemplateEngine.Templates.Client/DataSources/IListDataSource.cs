using Neptuo.TemplateEngine.Web;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.DataSources
{
    /// <summary>
    /// Javascript implementation of <see cref="IListDataSource"/>.
    /// </summary>
    public interface IClientListDataSource
    {
        void GetData(int? pageIndex, int? pageSize, Action<IListResult> callback, Action<ErrorModel> errorCallback);
    }
}

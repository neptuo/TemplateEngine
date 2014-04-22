using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neptuo.TemplateEngine.Web;

namespace Neptuo.TemplateEngine.Templates.DataSources
{
    public class ClientCollectionDataSource : IClientListDataSource
    {
        public IEnumerable Data { get; set; }

        public void GetData(int? pageIndex, int? pageSize, Action<IListResult> callback, Action<ErrorModel> errorCallback)
        {
            callback(new ListResult(Data, 0));
        }
    }
}

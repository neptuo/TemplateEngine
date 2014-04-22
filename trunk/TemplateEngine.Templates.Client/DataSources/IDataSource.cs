using Neptuo.TemplateEngine.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.DataSources
{
    public interface IClientDataSource
    {
        void GetItem(Action<object> callback, Action<ErrorModel> errorCallback);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Navigation
{
    public interface INavigateTo
    {
        void Param(string key, object value);
        void Open();
    }
}

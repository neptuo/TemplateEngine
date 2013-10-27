using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Navigation
{
    public interface INavigator
    {
        void Open(FormUri formUri);
        INavigateTo NavigateTo(FormUri formUri);
    }
}

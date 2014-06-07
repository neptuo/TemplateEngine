using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Navigation.Bootstrap
{
    public interface IFormUriRegistry
    {
        IFormUriRegistry Register(string identifier, string url);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Providers
{
    public interface ITemplateUrlFormatter
    {
        string FormatUrl(string urlPart);
    }
}

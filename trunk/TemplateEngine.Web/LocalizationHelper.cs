using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public static class LocalizationHelper
    {
        public static string Translate(string text)
        {
            return String.Format("[{0}]", text);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    /// <summary>
    /// Helper for localizing template vlaue.
    /// </summary>
    public static class LocalizationHelper
    {
        public static string Translate(string text)
        {
            //return String.Format("[{0}]", text);
            return text;
        }
    }
}

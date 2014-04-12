using Neptuo.Templates.Compilation.CodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Compilation.CodeObjects
{
    public class LocalizationCodeObject : ICodeObject
    {
        public string Text { get; set; }
        
        public LocalizationCodeObject(string text)
        {
            Text = text;
        }
    }
}

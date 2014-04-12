using Neptuo.Templates.Compilation.CodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Compilation.CodeObjects
{
    public class ResolveUrlCodeObject : ICodeObject
    {
        public string RelativeUrl { get; set; }

        public ResolveUrlCodeObject(string relativeUrl)
        {
            RelativeUrl = relativeUrl;
        }
    }
}

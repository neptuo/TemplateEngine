using Neptuo.PresentationModels;
using Neptuo.TemplateEngine.Templates.DataSources;
using SharpKit.JavaScript;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine
{
    public class ModelValueGetterListResult : ListResult
    {
        public ModelValueGetterListResult(IEnumerable data, int totalCount)
            : base(data, totalCount)
        { }

        public class ModelValueGetter : IModelValueGetter
        {
            private JsObject source;

            public ModelValueGetter(JsObject source)
            {
                this.source = source;
            }

            public bool TryGetValue(string identifier, out object value)
            {
                if (source == null)
                {
                    value = null;
                    return false;
                }

                if (String.IsNullOrEmpty(identifier))
                {
                    value = source;
                    return true;
                }

                JsObject currentSource = source;
                string[] exprs = identifier.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < exprs.Length; i++)
                {
                    currentSource = currentSource[exprs[i]].As<JsObject>();
                    if(currentSource == null)
                        break;
                }


                value = currentSource;
                return true;
            }
        }
    }
}

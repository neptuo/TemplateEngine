using Neptuo.PresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class DictionaryViewStorage : IViewStorage
    {
        private Dictionary<string, IFieldView> storage = new Dictionary<string, IFieldView>();

        public IFieldView this[string identifier]
        {
            get
            {
                IFieldView fieldView;
                if (storage.TryGetValue(identifier, out fieldView))
                    return fieldView;

                return null;
            }
            set { storage[identifier] = value; }
        }
    }
}

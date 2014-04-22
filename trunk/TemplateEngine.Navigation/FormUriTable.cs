using Neptuo.TemplateEngine.Navigation.Bootstrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Navigation
{
    public static class FormUriTable
    {
        private static DefaultFormUriRepository instance;

        public static IFormUriRepository Repository
        {
            get
            {
                if (instance == null)
                    instance = new DefaultFormUriRepository();

                return instance;
            }
        }

        public static IFormUriRegistry Registry
        {
            get
            {
                if (instance == null)
                    instance = new DefaultFormUriRepository();

                return instance;
            }
        }
    }
}

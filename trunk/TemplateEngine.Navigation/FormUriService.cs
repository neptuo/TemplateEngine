using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Navigation
{
    public static class FormUriService
    {
        private static IFormUriService instance;

        public static IFormUriService Instance
        {
            get
            {
                if (instance == null)
                    throw new InvalidOperationException("Using navigation singleton without set this instance.");

                return instance;
            }
        }

        internal static void SetInstance(IFormUriService service)
        {
            instance = service;
        }
    }
}

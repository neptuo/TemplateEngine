using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class Application : IApplication
    {
        public static IApplication Instance { get; private set; }

        public string[] DefaultToUpdate { get; private set; }
        public IHistoryState HistoryState { get; private set; }

        public static void Start()
        {
            if (Instance != null)
                throw new ApplicationException("Application is already started."); //TODO: Ehm, be quiet?


        }
    }
}

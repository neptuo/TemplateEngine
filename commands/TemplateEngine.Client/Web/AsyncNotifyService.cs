using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    /// <summary>
    /// Service for maintaing pending async requests.
    /// </summary>
    public class AsyncNotifyService
    {
        private int counter = 0;
        private HashSet<object> sources = new HashSet<object>();

        public event Action OnReady;
        
        public bool IsReady
        {
            get { return counter == 0; }
        }

        public void Register(object source)
        {
            if (sources.Add(source))
                counter++;
        }

        public void NotifyDone(object source)
        {
            if (sources.Remove(source))
                counter--;

            if (counter == 0 && OnReady != null)
                OnReady();
        }
    }
}

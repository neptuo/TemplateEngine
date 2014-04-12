using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
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
            if (sources.Remove(sources))
            {
                counter--;

                if (OnReady != null)
                    OnReady();
            }
        }
    }
}

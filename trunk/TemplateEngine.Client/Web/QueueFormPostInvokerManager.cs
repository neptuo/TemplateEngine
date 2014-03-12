using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class QueueFormPostInvokerManager : IFormPostInvokerManager
    {
        private bool isRunning = false;
        private List<IFormPostInvoker> invokers = new List<IFormPostInvoker>();

        public void Invoke(IFormPostInvoker invoker)
        {
            invoker.OnSuccess += OnSuccess;
            invokers.Add(invoker);

            if(!isRunning)
                InvokeFirst();
        }

        private void OnSuccess(IFormPostInvoker invoker)
        {
            invokers.Remove(invoker);
            isRunning = false;

            InvokeFirst();
        }

        private void InvokeFirst()
        {
            IFormPostInvoker invoker = invokers.FirstOrDefault();
            if (invoker != null)
            {
                invoker.Invoke();
                isRunning = true;
            }
        }
    }
}

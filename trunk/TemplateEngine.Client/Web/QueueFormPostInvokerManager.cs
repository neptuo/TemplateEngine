using SharpKit.Html;
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
            invoker.OnError += OnError;
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

        private void OnError(IFormPostInvoker invoker, ErrorModel error)
        {
            invokers.Remove(invoker);

            if (HtmlContext.confirm("There was an error processing your request. Do you want to try again? If you say no, this page will be reloaded..."))
            {
                invokers.Insert(0, invoker);
                InvokeFirst();
            }
            else
            {
                HtmlContext.location.reload();
            }
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

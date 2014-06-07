using SharpKit.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class QueueControllerInvokeManager : IControllerInvokeManager
    {
        private bool isRunning = false;
        private List<IControllerInvoker> invokers = new List<IControllerInvoker>();

        public void Invoke(IControllerInvoker invoker)
        {
            invoker.OnSuccess += OnSuccess;
            invoker.OnError += OnError;
            invokers.Add(invoker);

            if(!isRunning)
                InvokeFirst();
        }

        private void OnSuccess(IControllerInvoker invoker)
        {
            invokers.Remove(invoker);
            isRunning = false;

            InvokeFirst();
        }

        private void OnError(IControllerInvoker invoker, ErrorModel error)
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
            IControllerInvoker invoker = invokers.FirstOrDefault();
            if (invoker != null)
            {
                invoker.Invoke();
                isRunning = true;
            }
        }
    }
}

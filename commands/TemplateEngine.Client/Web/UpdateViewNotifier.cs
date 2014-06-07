using SharpKit.jQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    /// <summary>
    /// Actual implementation of <see cref="IUpdateViewNotifier"/>.
    /// </summary>
    public class UpdateViewNotifier : IUpdateViewNotifier
    {
        public UpdateViewNotifier(IMainView mainView)
        {
            mainView.OnBeforeRenderView += OnBeforeRenderView;
            mainView.OnAfterRenderView += OnAfterRenderView;
        }

        private void OnBeforeRenderView(string viewPath, string[] toUpdate)
        {
            StartUpdate();
        }

        private void OnAfterRenderView()
        {
            EndUpdate();
        }

        public void StartUpdate()
        {
            new jQuery("body").css("opacity", 0.5);
        }

        public void EndUpdate()
        {
            new jQuery("body").css("opacity", 1);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neptuo.TemplateEngine.Web
{
    public interface IUpdateViewNotifier
    {
        void StartUpdate();
        void EndUpdate();
    }
}

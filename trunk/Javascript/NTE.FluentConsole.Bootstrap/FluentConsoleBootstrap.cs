using SharpKit.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.FluentConsole.Bootstrap
{
    internal class FluentConsoleBootstrap
    {
        public static void Start()
        {
            Type consoleType = Type.GetType("Neptuo.TemplateEngine.FluentConsole.ConsoleDesk");
            IRunnable runnable = (IRunnable)Activator.CreateInstance(consoleType);
            runnable.Start();
        }
    }
}

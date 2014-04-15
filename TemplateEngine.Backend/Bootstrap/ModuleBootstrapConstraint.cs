using Neptuo.Bootstrap.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Backend.Bootstrap
{
    public class ModuleBootstrapConstraint : IBootstrapConstraint
    {
        private readonly Type bootstrapTask;

        public ModuleBootstrapConstraint(Type bootstrapTask)
        {
            Guard.NotNull(bootstrapTask, "bootstrapTask");
            this.bootstrapTask = bootstrapTask;
        }

        public bool Satisfies(IBootstrapConstraintContext context)
        {
            ModuleAttribute module = bootstrapTask.GetCustomAttribute<ModuleAttribute>();
            return module != null;
        }
    }
}

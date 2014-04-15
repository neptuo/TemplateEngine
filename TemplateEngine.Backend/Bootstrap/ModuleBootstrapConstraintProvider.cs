using Neptuo.Bootstrap.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Backend.Bootstrap
{
    public class ModuleBootstrapConstraintProvider : IBootstrapConstraintProvider
    {
        public IEnumerable<IBootstrapConstraint> GetConstraints(Type bootstrapTask)
        {
            return new IBootstrapConstraint[] { new ModuleBootstrapConstraint(bootstrapTask) };
        }
    }
}

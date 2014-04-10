using Neptuo.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateEngine.Data.Entity
{
    public class DataContextUnitOfWorkFactory : DbContextUnitOfWorkFactory<DataContext>
    {
        public DataContextUnitOfWorkFactory(DataContext dataContext)
            : base(dataContext)
        { }
    }
}

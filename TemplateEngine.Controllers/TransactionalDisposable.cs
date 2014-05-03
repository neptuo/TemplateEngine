using Neptuo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Controllers
{
    internal class TransactionalDisposable
    {
        private readonly IUnitOfWork transaction;

        public TransactionalDisposable(IUnitOfWork transaction)
        {
            this.transaction = transaction;
        }

        public void Dispose(bool saveChanges)
        {
            if (transaction != null && saveChanges)
                transaction.SaveChanges();
        }
    }
}

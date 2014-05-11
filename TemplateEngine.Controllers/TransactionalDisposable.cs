using Neptuo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Controllers
{
    /// <summary>
    /// Helper class for maintaing action method transactional behavioral.
    /// </summary>
    internal class TransactionalDisposable
    {
        /// <summary>
        /// Unit of work (if not null) to commit on successfull commit.
        /// </summary>
        private readonly IUnitOfWork transaction;

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="transaction">Unit of work (if not null) to commit on successfull commit.</param>
        public TransactionalDisposable(IUnitOfWork transaction)
        {
            this.transaction = transaction;
        }

        /// <summary>
        /// If <paramref name="saveChanges"/> is true and has transaction, commits it.
        /// </summary>
        public void Dispose(bool saveChanges)
        {
            if (transaction != null && saveChanges)
                transaction.SaveChanges();
        }
    }
}

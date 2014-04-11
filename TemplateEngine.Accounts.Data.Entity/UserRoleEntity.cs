using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data.Entity
{
    [Table("UserRoles")]
    public class UserRoleEntity : UserRole
    {
        [Key]
        public override int Key
        {
            get { return base.Key; }
            set { base.Key = value; }
        }

        [Timestamp, ConcurrencyCheck]
        public override byte[] Version
        {
            get { return base.Version; }
            set { base.Version = value; }
        }

        public List<UserAccountEntity> UserAccounts { get; set; }
    }
}

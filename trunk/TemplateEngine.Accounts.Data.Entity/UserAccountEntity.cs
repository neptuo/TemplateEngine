using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data.Entity
{
    [Table("UserAccounts")]
    public class UserAccountEntity : UserAccount
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

        [NotMapped]
        public override List<UserRole> Roles { get; set; }

        public virtual List<UserRoleEntity> RoleEntities
        {
            get
            {
                if (Roles == null)
                    return null;

                List<UserRoleEntity> roles = new List<UserRoleEntity>();
                Roles.ForEach(role => roles.Add((UserRoleEntity)role));
                return roles;
            }
            set
            {
                if (value != null) 
                    Roles = new List<UserRole>(value);
                else
                    Roles = null;
            }
        }
    }
}

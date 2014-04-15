using Neptuo.Data.Entity;
using Neptuo.TemplateEngine.Accounts.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data.Entity
{
    public class DataContext : DbContext, IDbContext
    {
        public IDbSet<UserAccount> UserAccounts { get; set; }
        public IDbSet<UserRole> UserRoles { get; set; }
        public IDbSet<UserLog> UserLogs { get; set; }

        public DataContext()
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            

            base.OnModelCreating(modelBuilder);
            MapUserAccount(modelBuilder.Entity<UserAccount>());
            MapUserRole(modelBuilder.Entity<UserRole>());
            MapUserLog(modelBuilder.Entity<UserLog>());
        }

        protected void MapUserAccount(EntityTypeConfiguration<UserAccount> userAccount)
        {
            userAccount
                .HasKey(u => u.Key)
                .Property(u => u.Version)
                .IsRowVersion();

            userAccount
                .HasMany(u => u.Roles).WithMany(r => r.Accounts).Map(x => x.ToTable("UserAccount_UserRole"));
        }

        protected void MapUserRole(EntityTypeConfiguration<UserRole> userRole)
        {
            userRole
                .HasKey(r => r.Key)
                .Property(r => r.Version)
                .IsRowVersion();

            userRole
                .HasMany(r => r.Accounts).WithMany(u => u.Roles).Map(x => x.ToTable("UserAccount_UserRole"));
        }

        protected void MapUserLog(EntityTypeConfiguration<UserLog> userLog)
        {
            userLog
                .HasKey(l => l.Key)
                .Property(r => r.Version)
                .IsRowVersion();

            userLog
                .Property(l => l.SignedIn)
                .IsRequired();

            userLog
                .Property(l => l.LastActivity)
                .IsRequired();

            userLog
                .HasRequired(l => l.User).WithMany();
        }
    }
}

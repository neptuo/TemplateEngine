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

        static DataContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
        }

        public DataContext()
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            MapUserAccount(modelBuilder.Entity<UserAccount>());
            MapUserRole(modelBuilder.Entity<UserRole>());
        }

        protected void MapUserAccount(EntityTypeConfiguration<UserAccount> userAccount)
        {
            userAccount
                .HasKey(u => u.Key)
                .Property(u => u.Version)
                .IsConcurrencyToken();

            userAccount
                .HasMany(u => u.Roles).WithMany(r => r.Accounts).Map(x => x.ToTable("UserAccount_UserRole"));
        }

        protected void MapUserRole(EntityTypeConfiguration<UserRole> userRole)
        {
            userRole
                .HasKey(r => r.Key)
                .Property(r => r.Version)
                .IsConcurrencyToken();

            userRole
                .HasMany(r => r.Accounts).WithMany(u => u.Roles).Map(x => x.ToTable("UserAccount_UserRole"));
        }
    }
}

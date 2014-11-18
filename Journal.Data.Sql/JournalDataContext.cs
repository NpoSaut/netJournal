using System.Data.Entity;
using Journal.Data.Sql.Entities;

namespace Journal.Data.Sql
{
    public class JournalDataContext : DbContext
    {
        public JournalDataContext()
            : base("name=JournalDataModel") { }

        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasMany(e => e.Sessions)
                        .WithRequired(e => e.User)
                        .WillCascadeOnDelete(false);
        }
    }
}

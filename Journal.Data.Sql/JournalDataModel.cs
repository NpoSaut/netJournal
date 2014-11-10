using System.Data.Entity;

namespace Journal.Data.Sql
{
    public class JournalDataModel : DbContext
    {
        public JournalDataModel()
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

using System.Data.Entity;

namespace DbAccess
{
    public interface IPostgresEntities
    {
        IDbSet<Contact> Contacts { get; set; }
        IDbSet<User> Users { get; set; }
        int SaveChanges();
    }

    public partial class PostgresEntities : DbContext, IPostgresEntities
    {
        public PostgresEntities()
            : base("name=Model1")
        {
        }

        public virtual IDbSet<Contact> Contacts { get; set; }
        public virtual IDbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.Contacts)
                .WithRequired(e => e.CreatedByUser)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Contacts1)
                .WithRequired(e => e.ModifiedByUser)
                .HasForeignKey(e => e.ModifiedBy)
                .WillCascadeOnDelete(false);
        }
    }
}

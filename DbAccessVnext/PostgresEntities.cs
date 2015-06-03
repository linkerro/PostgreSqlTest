using Microsoft.Data.Entity;
using System.Collections.Generic;

namespace DbAccess
{
    public interface IPostgresEntities
    {
        DbSet<Contact> Contacts { get; set; }
        DbSet<User> Users { get; set; }
        int SaveChanges();
    }

    public partial class PostgresEntities : DbContext, IPostgresEntities
    {
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"PORT=5432;TIMEOUT=15;POOLING=True;MINPOOLSIZE=1;MAXPOOLSIZE=20;COMMANDTIMEOUT=20;COMPATIBLE=2.2.5.0;PASSWORD=asdqwe123;USER ID=postgres;HOST=10.2.0.211;DATABASE=PgTest;PRELOADREADER=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Collection(e => e.CreatedContacts)
                .InverseReference(c => c.CreatedByUser)
                .ForeignKey(c => c.CreatedBy)
                .Required();

            modelBuilder.Entity<User>()
                .Collection(e => e.ModifiedContacts)
                .InverseReference(c => c.ModifiedByUser)
                .ForeignKey(c => c.ModifiedBy)
                .Required();
        }
    }
}

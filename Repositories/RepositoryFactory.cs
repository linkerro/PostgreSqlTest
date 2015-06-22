using DbAccess;

namespace Repositories
{
    public class RepositoryFactory
    {
        private PostgresEntities _postgresEntities = new PostgresEntities();

        public ContactRepository GetContactRepository()
        {
            return new ContactRepository(_postgresEntities);
        }
    }
}

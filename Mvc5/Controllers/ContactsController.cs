using System.Collections.Generic;
using System.Web.Http;
using DbAccess;
using Repositories;

namespace Mvc5.Controllers
{
    public class ContactsController : ApiController
    {
        private RepositoryFactory _repositories;
        private ContactRepository _contactRepository;

        public ContactsController()
        {
            _repositories = new RepositoryFactory();
            _contactRepository = _repositories.GetContactRepository();
        }

        // GET: api/Contacts
        public IEnumerable<Contact> Get(int pageNumber=1, int pageSize=20, string orderBy="FirstName", string sortOrder="ascending", string searchTerm=null)
        {
            return _contactRepository.GetContacts(pageNumber, pageSize, orderBy, sortOrder, searchTerm);
        }

        // GET: api/Contacts/5
        public Contact Get(int id)
        {
            return _contactRepository.GetContact(id);
        }

        // POST: api/Contacts
        public void Post([FromBody]Contact value)
        {
        }

        // PUT: api/Contacts/5
        public void Put(int id, [FromBody]Contact value)
        {
        }

        // DELETE: api/Contacts/5
        public void Delete(int id)
        {
        }
    }
}

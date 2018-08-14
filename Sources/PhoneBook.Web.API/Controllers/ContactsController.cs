using System;
using System.Web.Http;
using PhoneBook.Business;
using PhoneBook.Domain;

namespace PhoneBook.Web.API.Controllers
{
    [RoutePrefix("contacts")]
    public class ContactsController : ApiController
    {
        private readonly ContactsBl _contactsBl;

        public ContactsController(ContactsBl contactsBl)
        {
            _contactsBl = contactsBl;
        }

        [Route]
        public Contact[] Get()
        {
            return _contactsBl.GetAll();
        }

        public void Post(Contact contact)
        {
            _contactsBl.Add(contact);
        }

        public void Delete(Guid id)
        {
            _contactsBl.Delete(id);
        }

        [HttpGet]
        public Contact[] Search(string searchPatter)
        {
            return _contactsBl.Search(searchPatter);
        }
    }
}
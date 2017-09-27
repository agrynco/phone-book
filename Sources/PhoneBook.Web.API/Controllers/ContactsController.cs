using System.Web.Http;
using PhoneBook.Domain;

namespace PhoneBook.Web.API.Controllers
{
    [RoutePrefix("contacts")]
    public class ContactsController : ApiController
    {
        [Route]
        public Contact[] Get()
        {
            return new Contact[0];
        }
    }
}
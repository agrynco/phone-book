using System;

namespace PhoneBook.Domain
{
    public class Contact
    {
        public string FirstName { get; set; }
        public Guid Id { get; set; }
        public string LastName { get; set; }
    }
}
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using PhoneBook.DAL.Abstract;
using PhoneBook.Domain;

namespace PhoneBook.DAL.Bin
{
    public class ContactsRepository : IContactsRepository, IDisposable
    {
        private readonly ConcurrentDictionary<Guid, Contact> _contacts;
        private readonly IContactsFileStreamCreateor _contactsFileStreamCreator;


        public ContactsRepository(IContactsFileStreamCreateor contactsFileStreamCreator)
        {
            _contactsFileStreamCreator = contactsFileStreamCreator;

            _contacts = new ConcurrentDictionary<Guid, Contact>();

            Load();
        }

        public void Add(Contact contact)
        {
            contact.Id = Guid.NewGuid();
            _contacts.TryAdd(contact.Id, contact);
        }

        public Contact[] GetAll()
        {
            return _contacts.Values.ToArray();
        }

        public Contact[] Search(string searchPattern)
        {
            return _contacts.Values.Where(contact => contact.FirstName.ToLower().Contains(searchPattern) ||
                                                     contact.FirstName.ToLower().Contains(searchPattern)).ToArray();
        }

        public void Remove(Contact contact)
        {
            Contact removedContact;
            _contacts.TryRemove(contact.Id, out removedContact);
        }

        public void Dispose()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (Stream stream = _contactsFileStreamCreator.Create())
            {
                formatter.Serialize(stream, GetAll());
            }
        }

        private void Load()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (Stream stream = _contactsFileStreamCreator.OpenForRead())
            {
                var contacts = (Contact[]) formatter.Deserialize(stream);
                foreach (Contact contact in contacts)
                {
                    _contacts.TryAdd(contact.Id, contact);
                }
            }
        }
    }
}
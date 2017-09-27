﻿using PhoneBook.DAL.Abstract;
using PhoneBook.Domain;

namespace PhoneBook.Business
{
    public class ContactsBl
    {
        private readonly IContactsRepository _contactsRepository;

        public ContactsBl(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }

        public void Add(Contact contact)
        {
            _contactsRepository.Add(contact);
        }

        public Contact[] GetAll()
        {
            return _contactsRepository.GetAll();
        }

        public void Remove(Contact contact)
        {
            _contactsRepository.Remove(contact);
        }

        public Contact[] Search(string searchPattern)
        {
            return _contactsRepository.Search(searchPattern);
        }
    }
}
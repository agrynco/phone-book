using PhoneBook.Domain;

namespace PhoneBook.DAL.Abstract
{
    public interface IContactsRepository
    {
        void Add(Contact contact);
        Contact[] GetAll();

        void Remove(Contact contact);

        /// <summary>
        /// Will search by <see cref="Contact.FirstName"/> or <see cref="Contact.LastName"/>
        /// </summary>
        /// <param name="searchPattern"></param>
        /// <returns></returns>
        Contact[] Search(string searchPattern);
    }
}
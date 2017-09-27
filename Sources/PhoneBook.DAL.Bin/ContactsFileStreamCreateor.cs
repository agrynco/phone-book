using System.IO;

namespace PhoneBook.DAL.Bin
{
    public class ContactsFileStreamCreateor : IContactsFileStreamCreateor
    {
        private readonly string _fileName;

        public ContactsFileStreamCreateor(string fileName)
        {
            _fileName = fileName;
        }

        public Stream OpenForRead()
        {
            return new FileStream(_fileName, FileMode.Open);
        }

        public Stream Create()
        {
            return new FileStream(_fileName, FileMode.Create);
        }
    }
}
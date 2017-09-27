using System.IO;

namespace PhoneBook.DAL.Bin
{
    public interface IContactsFileStreamCreateor
    {
        Stream Create();
        Stream OpenForRead();
    }
}
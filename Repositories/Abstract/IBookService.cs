using BookStore_YT.Models.Domain;

namespace BookStore_YT.Repositories.Abstract
{
    public interface IBookService
    {
        bool  Add(Book book);
        bool Update(Book book);
        bool  Delete(int id);
        Book FindById(int id);
        IEnumerable<Book> GetAll();
    }
}

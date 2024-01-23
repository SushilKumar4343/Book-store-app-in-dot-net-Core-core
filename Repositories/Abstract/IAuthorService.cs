using BookStore_YT.Models.Domain;

namespace BookStore_YT.Repositories.Abstract
{
    public interface IAuthorService
    {
        bool  Add(Author book);
        bool Update(Author book);
        bool  Delete(int id);
        Author FindById(int id);
        IEnumerable<Author> GetAll();
    }
}

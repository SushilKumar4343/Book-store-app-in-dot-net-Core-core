using BookStore_YT.Models.Domain;

namespace BookStore_YT.Repositories.Abstract
{
    public interface IPublisherService
    {
        bool  Add(Publisher publisher);
        bool Update(Publisher publisher);
        bool  Delete(int id);
        Publisher FindById(int id);
        IEnumerable<Publisher> GetAll();
    }
}

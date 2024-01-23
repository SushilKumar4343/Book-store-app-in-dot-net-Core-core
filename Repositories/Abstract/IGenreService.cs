using BookStore_YT.Models.Domain;

namespace BookStore_YT.Repositories.Abstract
{
    public interface IGenreService
    {
        bool Add(Genre model);
        bool Update(Genre model);
        bool Delete(int id);
        Genre FindByid(int id);
        IEnumerable<Genre> GetAll();
    }
}

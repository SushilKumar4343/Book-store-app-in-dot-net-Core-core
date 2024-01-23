using BookStore_YT.Data;
using BookStore_YT.Models.Domain;
using BookStore_YT.Repositories.Abstract;

namespace BookStore_YT.Repositories.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly ApplicationDbContext _context;

        public GenreService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Genre model)
        {
            try
            {
                _context.Genres.Add(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.FindByid(id);
                if (data == null)
                    return false;
                _context.Remove(data);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Genre FindByid(int id)
        {
            return _context.Genres.Find(id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return _context.Genres.ToList();
        }

        public bool Update(Genre model)
        {
            try
            {
                _context.Genres.Update(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}

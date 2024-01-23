using BookStore_YT.Data;
using BookStore_YT.Models.Domain;
using BookStore_YT.Repositories.Abstract;

namespace BookStore_YT.Repositories.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationDbContext  _context;

        public AuthorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Author author)
        {
            try
            {
                _context.Authors.Add(author);
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
                var data = this.FindById(id);
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

        public Author FindById(int id)
        {
            return _context.Authors.Find(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public bool Update(Author author)
        {
            try
            {
                _context.Authors.Update(author);
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

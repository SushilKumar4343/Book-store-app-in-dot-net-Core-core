using BookStore_YT.Data;
using BookStore_YT.Models.Domain;
using BookStore_YT.Repositories.Abstract;

namespace BookStore_YT.Repositories.Implementation
{
    public class PublisherService : IPublisherService
    {
        private readonly ApplicationDbContext _context;

        public PublisherService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Publisher model)
        {
            try
            {
                _context.Publishers.Add(model);
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

        public Publisher FindById(int id)
        {
            return _context.Publishers.Find(id);
        }

        public IEnumerable<Publisher> GetAll()
        {
            return _context.Publishers.ToList();
        }

        public bool Update(Publisher model)
        {
            try
            {
                _context.Publishers.Update(model);
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

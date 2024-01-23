using BookStore_YT.Data;
using BookStore_YT.Models.Domain;
using BookStore_YT.Repositories.Abstract;

namespace BookStore_YT.Repositories.Implementation
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Book book)
        {
            try
            {
                _context.Books.Add(book);
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

        public Book FindById(int id)
        {
            return _context.Books.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            var data = (from book in _context.Books
                        join author in _context.Authors
                        on book.AuthorId equals author.Id
                        join publisher in _context.Publishers on book.PublishId equals publisher.Id
                        join genre in _context.Genres on book.GenreId equals genre.Id
                        select new Book
                        {
                            Id = book.Id,
                            AuthorId = author.Id,
                            GenreId = book.GenreId,
                            Isbn = book.Isbn,
                            PublishId = book.PublishId,
                            Titile = book.Titile,
                            TotalPage = book.TotalPage,
                            GenreName = genre.Name,
                            AuthorName = author.AuthorName,
                            PublisherName = publisher.PublisherName
                        }
                        ).ToList();
            return data;
        }

        public bool Update(Book book)
        {
            try
            {
                _context.Books.Update(book);
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

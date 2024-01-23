using System.ComponentModel.DataAnnotations;

namespace BookStore_YT.Models.Domain
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        public string AuthorName { get; set; }
    }
}

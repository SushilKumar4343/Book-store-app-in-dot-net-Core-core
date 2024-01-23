using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace BookStore_YT.Models.Domain
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}

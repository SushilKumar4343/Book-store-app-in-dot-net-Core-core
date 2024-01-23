using System.ComponentModel.DataAnnotations;

namespace BookStore_YT.Models.Domain
{
    public class Publisher
    {
        public int Id { get; set; }
        [Required]
        public string PublisherName { get; set; }
    }
}

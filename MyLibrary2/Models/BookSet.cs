using System.ComponentModel.DataAnnotations;

namespace MyLibrary2.Models
{
    public class BookSet
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary2.Models
{
    public class Shelf
    {
        [Key]
        public int Id { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        [Display(Name = "Library")]
        public int LibraryId { get; set; }
        public Library? Library { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
        [NotMapped]
        public double EmptySpace { get => Books != null ? Width - Books.Sum(b => b.Width): Width; }
    }
}

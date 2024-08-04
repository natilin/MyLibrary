using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary2.Models
{
    public class Shelf
    {
        [Key]
        [Display(Name = "מספר מדף")]

        public int Id { get; set; }
        [Display(Name = "גובה")]
        public int Height { get; set; }
        [Display(Name = "רוחב")]
        public int Width { get; set; }

        [Display(Name = "ספריה")]
        public int LibraryId { get; set; }
        public Library? Library { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
        [NotMapped]
        [Display(Name = "מקום פנוי")]
        public double EmptySpace { get => Books != null ? Width - Books.Sum(b => b.Width): Width; }
    }
}

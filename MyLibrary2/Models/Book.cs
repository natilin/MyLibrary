using System.ComponentModel.DataAnnotations;

namespace MyLibrary2.Models
{
    public class Book
    {

        [Key]
        public int Id { get; set; }
        [Display(Name="שם")]
        public string Name { get; set; }
        [Display(Name = "גובה")]
        public int Height { get; set; }
        [Display(Name = "רוחב")]
        public int Width { get; set; }
        [Display(Name = "מספר מדף")]
        public int ShelfId { get; set; }
        public Shelf? Shelf { get; set; }
        public int? BookSetId {  get; set; }
        public BookSet? BookSet { get; set; }

    }
}

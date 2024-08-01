using System.ComponentModel.DataAnnotations;

namespace MyLibrary2.Models
{
    public class Book
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int ShelfId { get; set; }
        public Shelf? Shelf { get; set; }
        public int? BookSetId {  get; set; }

    }
}

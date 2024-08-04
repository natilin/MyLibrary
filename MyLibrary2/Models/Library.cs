using System.ComponentModel.DataAnnotations;

namespace MyLibrary2.Models
{
    public class Library
    {
        //[Index(nameof(Name), IsUnique = true)]

            [Key]
            public int Id { get; set; }
            [Display(Name = "ז'אנר")]
            public string Name { get; set; }
            public ICollection<Shelf> Shelves { get; } = new List<Shelf>();

    }
}

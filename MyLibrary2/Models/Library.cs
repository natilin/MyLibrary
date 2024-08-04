using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary2.Models
{

    [Index(nameof(Name), IsUnique = true)]
    public class Library
    {


            [Key]
            public int Id { get; set; }
            [Display(Name = "ז'אנר")]
            public string Name { get; set; }
            public ICollection<Shelf> Shelves { get; } = new List<Shelf>();

    }
}

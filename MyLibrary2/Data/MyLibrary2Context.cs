using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyLibrary2.Models;

namespace MyLibrary2.Data
{
    public class MyLibrary2Context : DbContext
    {
        public MyLibrary2Context (DbContextOptions<MyLibrary2Context> options)
            : base(options)
        {
        }

        public DbSet<MyLibrary2.Models.Library> Library { get; set; } = default!;
        public DbSet<MyLibrary2.Models.Shelf> Shelf { get; set; } = default!;
        public DbSet<MyLibrary2.Models.Book> Book { get; set; } = default!;
        public DbSet<MyLibrary2.Models.BookSet> BookSet { get; set; } = default!;
    }
}

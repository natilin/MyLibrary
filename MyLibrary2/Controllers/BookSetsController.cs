using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyLibrary2.Data;
using MyLibrary2.Models;

namespace MyLibrary2.Controllers
{
    public class BookSetsController : Controller
    {
        private readonly MyLibrary2Context _context;

        public BookSetsController(MyLibrary2Context context)
        {
            _context = context;
        }

        // GET: BookSets
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookSet.Include(b => b.Books).ToListAsync());
        }

        // GET: BookSets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookSet = await _context.BookSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookSet == null)
            {
                return NotFound();
            }

            return View(bookSet);
        }

        // GET: BookSets/Create
        public IActionResult Create()
        {
            ViewBag.Libraries = new SelectList(_context.Library, "Id", "Name");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetShelfs(int libraryId, int MaxHeight, int TotalWidth)
        {
            try
            {
                List<Shelf> shelfs = _context.Shelf.Where(s => s.LibraryId == libraryId && s.Width > TotalWidth && s.Height > MaxHeight).ToList()
                    .Where(s => s.EmptySpace > TotalWidth).ToList();
                var shelfData = new SelectList(shelfs, "Id", "Id");
                return Json(shelfData);
            }
            catch (Exception e)
            {

                throw;
            }


        }

        // POST: BookSets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookSet bookSet, int ShelfId)
        {
            if (ModelState.IsValid)
            {
                foreach (var book in bookSet.Books)
                {
                    book.BookSet = bookSet;
                    book.ShelfId = ShelfId;
                }
                _context.Add(bookSet);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index)); ;
        }

        // GET: BookSets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookSet = await _context.BookSet.FindAsync(id);
            if (bookSet == null)
            {
                return NotFound();
            }
            return View(bookSet);
        }

        // POST: BookSets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] BookSet bookSet)
        {
            if (id != bookSet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookSet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookSetExists(bookSet.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bookSet);
        }

        // GET: BookSets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookSet = await _context.BookSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookSet == null)
            {
                return NotFound();
            }

            return View(bookSet);
        }

        // POST: BookSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookSet = await _context.BookSet.FindAsync(id);
            if (bookSet != null)
            {
                _context.BookSet.Remove(bookSet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookSetExists(int id)
        {
            return _context.BookSet.Any(e => e.Id == id);
        }

        public  IActionResult CreateBook(BookSet bookSet)
        {
           return View(bookSet);
        }

      
    }
}

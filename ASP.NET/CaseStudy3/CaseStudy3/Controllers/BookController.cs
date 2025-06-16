using CaseStudy3.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy3.Controllers
{
    public class BookController : Controller
    {
        private static List<Book> books = new List<Book>();

        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            if (books.Any(b => b.Isbn == book.Isbn))
            {
                ModelState.AddModelError("Isbn", "ISBN must be unique");
            }

            if (ModelState.IsValid)
            {
                books.Add(book);
                return RedirectToAction("BookList");
            }

            return View(book);
        }

        public IActionResult BookList()
        {
            return View(books);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVxPatterns1.Models;

namespace MVxPatterns1.Controllers
{
    public class BooksController : Controller
    {
        private BooksContext _context = new BooksContext();

        public IActionResult Index()
        {
            IEnumerable<Book> books = _context.Books;
            ViewBag.Books = books;
            return View();
        }

        public IActionResult Read()
        {
            IEnumerable<Book> books = _context.Books;
            ViewBag.Books = books;
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult OlderThanTwoThousand()
        {
            IEnumerable<Book> books = _context.Books.Where(book => book.ReleaseDate.Year < 2000);
            ViewBag.Books = books;
            return View();
        }

    }
}
using System;
using DevTest.Interfaces;
using DevTest.Models;
using DevTest.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace DevTest.Controllers
{
    public class BookController : Controller
    {

        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;

        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            List<BookListResponse> bookList = await _bookService.GetAll();

            ViewData["Books"] = bookList;

            return View(bookList);
        }

        public IActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(string id)
        {
            var book = _bookService.GetById(id).Result;
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(BookListResponse book)
        {
            if (book != null)
            {
                var response = await _bookService.Update(book);

                if (response != null)
                {
                    return RedirectToAction("Index");
                }
            }

            return View("RegisterError");
        }

        [HttpPost]
        public async Task<IActionResult> SubmitBook(BookCreate book)
        {
            if (book != null)
            {
                var response = await _bookService.Create(book);

                if (response != null)
                {
                    return RedirectToAction("Index");
                }
            }

            return View("RegisterError");
        }
    }
}

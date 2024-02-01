using System;
using DevTest.Interfaces;
using DevTest.Models;
using DevTest.Models.Response;
using DevTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevTest.Controllers
{
	public class AuthorController : Controller
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly IAuthorService _authorService;

        public AuthorController(ILogger<AuthorController> logger, IAuthorService authorService)
        {
            _logger = logger;
            _authorService = authorService;
        }
         
        public async Task<IActionResult> Index()
        {
            List<AuthorListResponse>  authorList = await _authorService.GetAll();

            ViewData["Authors"] = authorList;
             
            return View(authorList);
        }

        public IActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(string id)
        {
            var author = _authorService.GetById(id).Result; 
            return View(author);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAuthor(AuthorListResponse author)
        {
            if (author != null)
            {
                var response = await _authorService.Update(author);

                if (response != null)
                {
                    return RedirectToAction("Index");
                }
            }

            return View("RegisterError");
        }

        [HttpPost]
        public async Task<IActionResult> SubmitAuthor(AuthorCreate author)
        {
            if (author != null)
            {
                var response = await _authorService.Create(author);

                if (response != null)
                {
                    return RedirectToAction("Index");
                }
            }

            return View("RegisterError");
        }
    }
}


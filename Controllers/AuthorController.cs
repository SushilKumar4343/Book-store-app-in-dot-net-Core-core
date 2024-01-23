using BookStore_YT.Models.Domain;
using BookStore_YT.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_YT.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService service;

        public AuthorController(IAuthorService service)
        {
            this.service = service;
        }

        public IActionResult GetAll()
        {
           var data = service.GetAll();
            return View(data);
        }
        public IActionResult Add()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Add(Author author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }
            var result = service.Add(author);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Error has been on server side";
            return View(author);
        }
        public IActionResult Edit(int id)
        {
            var record = service.FindById(id);
            return View(record);
        }
        [HttpPost]
        public IActionResult Edit(Author author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }
            var result = service.Update(author);
            if (result)
            {
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Error has been on server side!";
            return View(author);
        }
        public IActionResult Delete(int id)
        {
            var record = service.Delete(id);
            return RedirectToAction("GetAll");
        }
    }
}

using BookStore_YT.Models.Domain;
using BookStore_YT.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_YT.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService service;

        public PublisherController(IPublisherService service)
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
        public IActionResult Add(Publisher model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = service.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Error has been on server side";
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var record = service.FindById(id);
            return View(record);
        }
        [HttpPost]
        public IActionResult Edit(Publisher model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = service.Update(model);
            if (result)
            {
                return RedirectToAction("GetAll");
            }
            TempData["msg"] = "Error has been on server side!";
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var record = service.Delete(id);
            return RedirectToAction("GetAll");
        }
    }
}

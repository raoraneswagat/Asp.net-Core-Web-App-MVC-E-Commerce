using Asp.net_Core_Web_App_MVC_E_Commerce.Data;
using Asp.net_Core_Web_App_MVC_E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_App_MVC_E_Commerce.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> categories = _db.Category.ToList();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {

            // if (obj.Name == obj.DisplayOrder.ToString())
            // {
            //     ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name");
            // }
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Added Successfully!";
                return RedirectToAction("Index");
            }
            return View();


        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            Category? category = _db.Category.Find(Id);

            if (category == null)
            {
                return NotFound();
            }
            // _db.Category.FirstOrDefault(c=>c.Id==Id);
            // _db.Category.Where(w=>w.Id==Id).FirstOrDefault();

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            // if (obj.Name == obj.DisplayOrder.ToString())
            // {
            //     ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name");
            // }
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Updated Successfully!";
                return RedirectToAction("Index");
            }
            return View();


        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Category category = _db.Category.Find(Id);

            if (category == null)
            {
                return NotFound();
            }
            // _db.Category.FirstOrDefault(c=>c.Id==Id);
            // _db.Category.Where(w=>w.Id==Id).FirstOrDefault();

            return View(category);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? Id)
        {

            Category? category = _db.Category.Find(Id);
            if (category == null)
            {
                return NotFound();
            }

            _db.Category.Remove(category);
            _db.SaveChanges();
            TempData["Success"] = "Category Deleted Successfully!";
            return RedirectToAction("Index");


        }

    }
}

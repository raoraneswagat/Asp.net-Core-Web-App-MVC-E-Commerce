using Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_App_MVC_E_Commerce.Controllers
{
    public class CategoryController : Controller
    {
        //private ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Category> categories = _unitOfWork.Category.GetAll().ToList();

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
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
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

            Category? category = _unitOfWork.Category.Get(c => c.Id == Id);

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
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
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
            Category category = _unitOfWork.Category.Get(c=>c.Id==Id);

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

            Category? category = _unitOfWork.Category.Get(c=>c.Id==Id);
            if (category == null)
            {
                return NotFound();
            }

            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();
            TempData["Success"] = "Category Deleted Successfully!";
            return RedirectToAction("Index");


        }

    }
}

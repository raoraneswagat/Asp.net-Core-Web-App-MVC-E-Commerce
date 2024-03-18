using Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModels;

namespace Asp.net_Core_Web_App_MVC_E_Commerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Product> products = _unitOfWork.Product.GetAll().ToList();


            return View(products);
        }

        public IActionResult Upsert(int? Id)
        {
            IEnumerable<SelectListItem> categories = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()

            });

            ProductVM productVM = new()
            {
                CategoryList = categories,
                Product = new Product()
            };

            if(Id!=null && Id!=0)
            {
                productVM.Product = _unitOfWork.Product.Get(p=>p.Id==Id);
            }

            return View(productVM);
        }

        [HttpPost]
        public IActionResult Upsert(ProductVM productVM,IFormFile? file)
        {

            // if (obj.Name == obj.DisplayOrder.ToString())
            // {
            //     ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name");
            // }
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(productVM.Product);
                _unitOfWork.Save();
                TempData["Success"] = "Product Added Successfully!";
                return RedirectToAction("Index");
            }
            {
                productVM.CategoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()

            });
            return View(productVM);
            }
            


        }


        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Product product = _unitOfWork.Product.Get(c => c.Id == Id);

            if (product == null)
            {
                return NotFound();
            }
            // _db.Category.FirstOrDefault(c=>c.Id==Id);
            // _db.Category.Where(w=>w.Id==Id).FirstOrDefault();

            return View(product);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? Id)
        {

            Product? product = _unitOfWork.Product.Get(c => c.Id == Id);
            if (product == null)
            {
                return NotFound();
            }

            _unitOfWork.Product.Remove(product);
            _unitOfWork.Save();
            TempData["Success"] = "Product Deleted Successfully!";
            return RedirectToAction("Index");


        }
    }
}
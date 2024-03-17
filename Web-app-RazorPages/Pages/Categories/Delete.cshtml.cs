using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_app_RazorPages;

namespace MyApp.Namespace
{
    [BindProperties]
    public class DeleteModel : PageModel
    {

        private ApplicationDbContext _db;
        public Category category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                category = _db.Category.Find(id);

            }
        }

        public IActionResult OnPost(int? id)
        {
            if (id != null && id != 0)
            {
                _db.Category.Remove(category);
                _db.SaveChanges();
                TempData["Success"] = "Category Deleted Successfully!";
                return RedirectToPage("Index");

            }

            return NotFound();
        }
    }
}

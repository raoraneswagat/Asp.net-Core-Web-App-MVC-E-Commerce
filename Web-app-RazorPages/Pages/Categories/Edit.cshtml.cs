using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_app_RazorPages;

namespace MyApp.Namespace
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public Category category { get; set; }
        public EditModel(ApplicationDbContext db)
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

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(category);
                _db.SaveChanges();

                return RedirectToPage("Index");
            }
            else
            {
                return NotFound();
            }
        }
    }
}

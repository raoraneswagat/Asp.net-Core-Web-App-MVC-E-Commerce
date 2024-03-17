using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_app_RazorPages;

namespace MyApp.Namespace
{
  public class CreateModel : PageModel
  {
    private ApplicationDbContext _db;
    public Category category { get; set; }
    public CreateModel(ApplicationDbContext db)
    {
      _db = db;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost(Category category)
    {

      if (ModelState.IsValid)
      {
        _db.Category.Add(category);
        _db.SaveChanges();
        TempData["Success"] = "Category Added Successfully!";
        return RedirectToPage("Index");
      }
      else
      {
        return NotFound();
      }

    }

  }
}

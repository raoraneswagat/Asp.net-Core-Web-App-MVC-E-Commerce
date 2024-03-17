using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_app_RazorPages;

namespace MyApp.Namespace
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _db;
        public List<Category> categories { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
           categories = _db.Category.ToList();
        }
    }
}

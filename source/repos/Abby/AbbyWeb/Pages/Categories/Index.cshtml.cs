using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IEnumerable<Category> Categories { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET METHOD
        public void OnGet()

        {
            var st = "";
            if (TempData["success"] != null)
            {
                st = (string)TempData["success"];
            }
            ViewData["data"] = st;
            Categories = _db.Category;
        }
    }
}

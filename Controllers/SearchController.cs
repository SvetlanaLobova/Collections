using Collections.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Collections.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SearchController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var items = _db.Items.Where(s => s.Name.Contains(searchString));
            var collections = _db.Collections.Where(s => s.Name.Contains(searchString) || s.Description.Contains(searchString));
            foreach (var obj in collections)
            {
                var collectionItems = _db.Items.Where(x => x.CollectionId == obj.Id);
                items = items.Concat(collectionItems).Distinct().OrderBy(x => x.Name);
            }
            return View(await items.ToListAsync());
        }
    }
}

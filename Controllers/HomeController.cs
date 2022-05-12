using Collections.Data;
using Collections.Models;
using Microsoft.AspNetCore.Mvc;

namespace Collections.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Collection> objCollectionList = _db.Collections;
            return View(objCollectionList);
        }
        public IActionResult Details(int id)
        {
            IEnumerable<Item> objItemList = _db.Items.Where(x => x.CollectionId == id).ToList();
            return View(objItemList);
        }
    }
}

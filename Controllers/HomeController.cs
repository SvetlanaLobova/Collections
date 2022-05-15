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
            var objCollectionList = _db.Collections;
            return View(objCollectionList);
        }
    }
}

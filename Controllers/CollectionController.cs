using Collections.Data;
using Collections.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Collections.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CollectionController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string id)
        {
            if(User.IsInRole("admin"))
            {
                GlobalAppUserId.UserId = id;
            }
            IEnumerable<Collection> objCollectionsList = _db.Collections.Where(x => x.UserCollectionId == GlobalAppUserId.UserId).ToList();
            return View(objCollectionsList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string Name, string Description, CollectionTheme Theme, string? FieldName, FieldType? TypeField, string? FieldName1, FieldType? TypeField1, string? FieldName2, FieldType? TypeField2)
        {
            if (ModelState.IsValid)
            {
                _db.Collections.Add(new Collection { Name = Name, Description = Description, Theme = Theme, UserCollectionId = GlobalAppUserId.UserId, FieldName = FieldName, TypeField = TypeField, FieldName1 = FieldName1, TypeField1 = TypeField1, FieldName2 = FieldName2, TypeField2 = TypeField2 });
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = GlobalAppUserId.UserId });
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            var collectionFromDb = _db.Collections.Find(id);
            return View(collectionFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string Name, string Description, CollectionTheme Theme, int id)
        {
            if (ModelState.IsValid)
            {
                var item = _db.Collections.Find(id);
                item.Name = Name;
                item.Description = Description;
                item.Theme = Theme;
                item.UserCollectionId = GlobalAppUserId.UserId;
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = GlobalAppUserId.UserId });
            }
            return View();
        }

        public IActionResult Del(int id)
        {
            var collectionFromDb = _db.Collections.Find(id);
            return View(collectionFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Del(Collection obj)
        {
            _db.Collections.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", new { id = GlobalAppUserId.UserId });
        }
    }
}

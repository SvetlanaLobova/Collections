using Collections.Data;
using Collections.Interfaces;
using Collections.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Collections.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IPhotoService _photoService;
        public CollectionController(ApplicationDbContext db, IPhotoService photoService)
        {
            _db = db;
            _photoService = photoService;
        }
        public IActionResult Index(string id)
        {
            if(User.IsInRole("admin"))
            {
                if (id != null)
                {
                    GlobalAppUserId.UserId = id;
                }
            }
            var objCollectionsList = _db.Collections.Where(x => x.UserCollectionId == GlobalAppUserId.UserId);
            return View(objCollectionsList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCollectionViewModel collectionVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(collectionVM.Image);
                var collection = new Collection
                {
                    Name = collectionVM.Name,
                    Description = collectionVM.Description,
                    Theme = collectionVM.Theme,
                    UserCollectionId = GlobalAppUserId.UserId,
                    FieldName = collectionVM.FieldName,
                    FieldName1 = collectionVM.FieldName1,
                    FieldName2 = collectionVM.FieldName2,
                    TypeField = collectionVM.TypeField,
                    TypeField1 = collectionVM.TypeField1,
                    TypeField2 = collectionVM.TypeField2
                };
                if (collectionVM.Image != null) 
                    collection.Image = result.Url.ToString();
                _db.Collections.Add(collection);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var collectionFromDb = _db.Collections.Find(id);
            return View(collectionFromDb);
        }
        [HttpPost]
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
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Del(int id)
        {
            var collectionFromDb = _db.Collections.Find(id);
            return View(collectionFromDb);
        }
        [HttpPost]
        public IActionResult Del(Collection obj)
        {
            _db.Collections.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

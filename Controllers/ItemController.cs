using Collections.Data;
using Collections.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Collections.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index(int id, string tag, string name, SortState sortOrder = SortState.NameAsc)
        {
            var items = _db.Items.Where(x => x.CollectionId == id);
            if (tag != null && name != null)
            {
                items = items.Where(s => s.Name.Contains(name) && s.Tag.Contains(tag));
                return View(items);
            }
            else
            {
                ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
                ViewData["TagSort"] = sortOrder == SortState.TagAsc ? SortState.TagDesc : SortState.TagAsc;
                items = sortOrder switch
                {
                    SortState.NameDesc => items.OrderByDescending(s => s.Name),
                    SortState.TagAsc => items.OrderBy(s => s.Tag),
                    SortState.TagDesc => items.OrderByDescending(s => s.Tag),
                    _ => items.OrderBy(s => s.Name),
                };

                GlobalCollection.CollectionId = id;
                var field = _db.Collections.Find(GlobalCollection.CollectionId);
                GlobalCollection.FieldName = field.FieldName;
                GlobalCollection.TypeField = field.TypeField;
                GlobalCollection.FieldName1 = field.FieldName1;
                GlobalCollection.TypeField1 = field.TypeField1;
                GlobalCollection.FieldName2 = field.FieldName2;
                GlobalCollection.TypeField2 = field.TypeField2;

                return View(await items.AsNoTracking().ToListAsync());
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string Name, string Tag, int? SpecialInt, int? SpecialInt1, 
            int? SpecialInt2, string? SpecialString, string? SpecialString1, string? SpecialString2, 
            string? SpecialText, string? SpecialText1, string? SpecialText2, DateTime? SpecialDataType, 
            DateTime? SpecialDataType1, DateTime? SpecialDataType2, bool? SpecialBool, bool? SpecialBool1, 
            bool? SpecialBool2)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Add(new Item { Name = Name, Tag = Tag, CollectionId = GlobalCollection.CollectionId, UserId = GlobalAppUserId.UserId,
                    SpecialInt = SpecialInt, SpecialInt1 = SpecialInt1, SpecialInt2 = SpecialInt2, 
                    SpecialString = SpecialString, SpecialString1 = SpecialString1, SpecialString2 = SpecialString2,
                    SpecialText = SpecialText, SpecialText1 = SpecialText1, SpecialText2 = SpecialText2,
                    SpecialDataType = SpecialDataType, SpecialDataType1 = SpecialDataType1, SpecialDataType2 = SpecialDataType2,
                    SpecialBool = SpecialBool, SpecialBool1 = SpecialBool1, SpecialBool2 = SpecialBool2});
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = GlobalCollection.CollectionId });
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var itemFromDb = _db.Items.Find(id);
            return View(itemFromDb);
        }
        [HttpPost]
        public IActionResult Edit(string Name, string Tag, int id, int? SpecialInt, int? SpecialInt1,
            int? SpecialInt2, string? SpecialString, string? SpecialString1, string? SpecialString2,
            string? SpecialText, string? SpecialText1, string? SpecialText2, DateTime? SpecialDataType,
            DateTime? SpecialDataType1, DateTime? SpecialDataType2, bool? SpecialBool, bool? SpecialBool1,
            bool? SpecialBool2)
        {
            if (ModelState.IsValid)
            {
                var item = _db.Items.Find(id);
                item.Name = Name;
                item.Tag = Tag;
                item.SpecialInt = SpecialInt;
                item.SpecialInt1 = SpecialInt1;
                item.SpecialInt2 = SpecialInt2;
                item.SpecialString = SpecialString;
                item.SpecialString1 = SpecialString1;
                item.SpecialString2 = SpecialString2;
                item.SpecialText = SpecialText;
                item.SpecialText1 = SpecialText1;
                item.SpecialText2 = SpecialText2;
                item.SpecialDataType = SpecialDataType;
                item.SpecialDataType1 = SpecialDataType1;
                item.SpecialDataType2 = SpecialDataType2;
                item.SpecialBool = SpecialBool;
                item.SpecialBool1 = SpecialBool1;
                item.SpecialBool2 = SpecialBool2;
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = GlobalCollection.CollectionId });
            }
            return View();
        }

        [HttpGet]
        public IActionResult Del(int id)
        {
            var itemFromDb = _db.Items.Find(id);
            return View(itemFromDb);
        }
        [HttpPost]
        public IActionResult Del(Item obj)
        {
            _db.Items.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", new { id = GlobalCollection.CollectionId });
        }
    }
}


using Collections.Data;
using Collections.Models;
using Microsoft.AspNetCore.Mvc;

namespace Collections.Controllers
{
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CommentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int id)
        {
            if (id != 0)
            {
                GlobalItemId.ItemId = id;
            }
            var objCommentList = _db.Comments.Where(x => x.ItemId == GlobalItemId.ItemId);
            return View(objCommentList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string Text)
        {
            if (ModelState.IsValid)
            {
                _db.Comments.Add(new Comment { Text = Text, ItemId = GlobalItemId.ItemId, UserId = GlobalAppUserId.UserId });
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Del(int id)
        {
            var commentFromDb = _db.Comments.Find(id);
            return View(commentFromDb);
        }
        [HttpPost]
        public IActionResult Del(Comment obj)
        {
            _db.Comments.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

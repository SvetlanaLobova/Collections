using Collections.Data;
using Collections.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Collections.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _db;
        public UserController(UserManager<AppUser> userManager, ApplicationDbContext db)
        {
            _db = db;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var objAppUserList = _db.AppUsers;
            return View(objAppUserList);
        }

        public async Task<IActionResult> AppointAdmin(string id)
        {
            var user = _db.AppUsers.Find(id);
            user.UserRole = "admin";
            await _userManager.RemoveFromRoleAsync(user, UserRoles.User);
            await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> AppointUser(string id)
        {
            var user = _db.AppUsers.Find(id);
            user.UserRole = "user";
            await _userManager.RemoveFromRoleAsync(user, UserRoles.Admin);
            await _userManager.AddToRoleAsync(user, UserRoles.User);
            return RedirectToAction("Index");
        }

        public IActionResult Block(string id)
        {
            var user = _db.AppUsers.Find(id);
            user.Status = Status.Blocked;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Unblock(string id)
        {
            var user = _db.AppUsers.Find(id);
            user.Status = Status.Active;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Del(string id)
        {
            var appuserFromDb = _db.AppUsers.Find(id);
            return View(appuserFromDb);
        }
        [HttpPost]
        public IActionResult Del(AppUser obj)
        {
            var user = _db.AppUsers.Find(obj.Id);
            _db.AppUsers.Remove(user);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

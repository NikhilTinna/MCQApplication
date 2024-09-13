using MCQApplication.Data;
using MCQApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace MCQApplication.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AuthController(ApplicationDbContext db) {
            _db = db;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }
        public IActionResult Login() {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<User> UserList = _db.Users;
                bool userFound = false, correctPass = false;

                foreach (var u in UserList)
                {
                    if (u.Username == user.Username)
                    {
                        userFound = true;
                        if (u.Password == user.Password)
                        {
                            correctPass = true;
                        }
                        break;
                    }
                }
                if (userFound && correctPass)
                {
                    CurrentUser.Username = user.Username;
                    CurrentUser.Password = user.Password;
                    CurrentUser.isLoggedIn = true;
                    return RedirectToAction("Index", "MCQ");
                }
                else if (userFound && !correctPass)
                {
                    TempData["IncorrectPassword"] = "Password is incorrect";
                    return View(user);
                }
                else if (!userFound)
                {
                    TempData["NoUser"] = "No such username found";
                    return View(user);
                }

            }
            return View(user);
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                var UserList = _db.Users.ToList();
                foreach (var u in UserList)
                {
                    if (u.Username == user.Username)
                    {
                        TempData["UserAlreadyExists"] = "Username already exists";
                        return View();
                    }
                }
                _db.Users.Add(user);
                _db.SaveChanges();
                CurrentUser.Username = user.Username;
                CurrentUser.Password = user.Password;
                CurrentUser.isLoggedIn = true;
                return RedirectToAction("Index", "MCQ");
            }
            return View(user);
        }
    }
}

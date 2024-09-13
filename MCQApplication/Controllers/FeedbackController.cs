using MCQApplication.Data;
using MCQApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace MCQApplication.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly ApplicationDbContext _db;
        public FeedbackController(ApplicationDbContext db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Feedback feedback)
        {

            if (!FeedbackTrack.FeedbackGiven)
            {
                if (ModelState.IsValid)
                {
                    _db.Feedback.Add(feedback);
                    _db.SaveChanges();
                    FeedbackTrack.FeedbackGiven = true;
                    return RedirectToAction("Success", "Feedback");
                }
            }
            return RedirectToAction("Success", "Feedback");
        }
        public IActionResult Success()
        {
            if (!FeedbackTrack.FeedbackGiven)
            {
                return RedirectToAction("Index", "Feedback");
            }
            return View();
        }
    }
}


using MCQApplication.Data;
using MCQApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace MCQApplication.Controllers
{
    public class MCQController : Controller

    {
		private readonly ApplicationDbContext _db;
		public MCQController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Test(IFormCollection form)
		{
			return View(form);	
		}
		[HttpPost]
		public IActionResult Index(PortIORterminal res)
		{
			if (res.Uid == null || res.Course == null || res.Year == null)
			{
				TempData["RequiredError"] = "All fields are required";
				return View();
			}
			PortIORterminal.StaticUid = res.Uid;
			PortIORterminal.StaticCourse = res.Course;
			PortIORterminal.StaticYear = res.Year;
			return RedirectToAction("Start");
		}
		public IActionResult Start()
		{
			return View();
		}

		public IActionResult Result()
		{
			return View();
		}		
		public ViewResult MCQ()
		{
			return View();
		}
		


		public IActionResult fyit()
		{
			IEnumerable<fyit> fyitList = _db.fyit;
			return View(fyitList);
		}
		[HttpPost]
		public IActionResult fyit(IFormCollection form)
		{
			
			List<string> answers = new List<string>();
			answers.Add(form["Q1"].ToString());
			answers.Add(form["Q2"].ToString());
			answers.Add(form["Q3"].ToString());
			answers.Add(form["Q4"].ToString());
			answers.Add(form["Q5"].ToString());
			IEnumerable<fyit> fyitList = _db.fyit;
			for (int i = 0; i < 5; i++)
			{
				if (answers[i] == fyitList.ElementAt(i).Answer)
				{
					Marks.fyitCorrect.Add(fyitList.ElementAt(i).Question);
				}
				else
				{
					Marks.fyitWrong.Add(fyitList.ElementAt(i).Question);
				}
			}
			return RedirectToAction("Result");

		}

        public IActionResult Syit()
        {
            IEnumerable<Syit> SyitList = _db.Syit;
            return View(SyitList);
        }
        [HttpPost]
        public IActionResult Syit(IFormCollection form)
        {
            List<string> answers = new List<string>();
            answers.Add(form["Q1"].ToString());
            answers.Add(form["Q2"].ToString());
            answers.Add(form["Q3"].ToString());
            answers.Add(form["Q4"].ToString());
            answers.Add(form["Q5"].ToString());
            IEnumerable<Syit> SyitList = _db.Syit;
            for (int i = 0; i < 5; i++)
            {
                if (answers[i] == SyitList.ElementAt(i).Answer)
                {
                    Marks.SyitCorrect.Add(SyitList.ElementAt(i).Question);
                }
                else
                {
                    Marks.SyitWrong.Add(SyitList.ElementAt(i).Question);
                }
            }
            return RedirectToAction("Result");

        }
    }
}

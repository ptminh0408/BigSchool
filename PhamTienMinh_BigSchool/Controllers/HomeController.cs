using PhamTienMinh_BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PhamTienMinh_BigSchool.ViewModels;

namespace PhamTienMinh_BigSchool.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext dbContext;
        public HomeController()
        {
            dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcommingCoures = dbContext.Courses
                .Include(s => s.Lecturer)
                .Include(s => s.Category)
                .Where(s => s.DateTime > DateTime.Now);

            var viewModel = new CoursesViewModel
            {
                UpcommingCourses = upcommingCoures,
                ShowAction = User.Identity.IsAuthenticated
            };

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
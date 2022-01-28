using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TeacherTools.Controllers
{
    public class StudentController : Controller
    {
        [Authorize]
        public IActionResult Viewing()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult DeleteStudent() {
            return RedirectToActionPermanent("Viewing", "Student");
        }

        [Authorize]
        [HttpPost]
        public IActionResult DeleteGroup()
        {
            return RedirectToActionPermanent("Viewing", "Student");
        }
    }
}

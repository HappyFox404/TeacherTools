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
    }
}

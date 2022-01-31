using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using TeacherTools.Data;
using TeacherTools.Models;
using TeacherTools.ViewModels.Student;

namespace TeacherTools.Controllers
{
    public class StudentController : Controller
    {
        [Authorize]
        [HttpGet]
        public IActionResult Viewing()
        {
            return View(new DatabaseLayer().GetStudents(User.Identity.Name));
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddStudent() {
            ViewData["Title"] = "Добавление обучающегося";
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddStudent(StudentAddModel model)
        {
            ViewData["Title"] = "Добавление обучающегося";
            if (ModelState.IsValid)
            {
                if (new DatabaseLayer().AddStudent(model.FirstName, model.LastName, model.Birthday, User.Identity.Name))
                {
                    return RedirectToActionPermanent("Viewing", "Student");
                }
                else 
                {
                    ModelState.AddModelError("", "У Вас в списке уже есть такой обучающийся");
                }
            }
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult DeleteStudent(string ids) {
            new DatabaseLayer().DelStudent(ids);
            return RedirectToActionPermanent("Viewing", "Student");
        }

        [Authorize]
        [HttpPost]
        public IActionResult DeleteGroup(string ids)
        {
            new DatabaseLayer().DelGroup(ids);
            return RedirectToActionPermanent("Viewing", "Student");
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddGroup() {
            ViewData["Title"] = "Добавление группы";
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddGroup(GroupAddModel model)
        {
            ViewData["Title"] = "Добавление группы";
            if (ModelState.IsValid)
            {
                if (new DatabaseLayer().AddGroup(model.Name,model.DateCreate,User.Identity.Name, model.About))
                {
                    return RedirectToActionPermanent("Viewing", "Student");
                }
                else
                {
                    ModelState.AddModelError("", "У Вас в списке уже есть такая группа");
                }
            }
            return View(model);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OdevTakip.Business.Services.Interfaces;

namespace OdevTakip.Web.Controllers
{
    public class StudentController : Controller
    {

        private ILessonService _lessonService;
        public StudentController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListStudentForLesson(int id)
        {
            ViewBag.Ders = _lessonService.GetById(id).Name;
            return View(_lessonService.ListStudentForLesson(id));
        }
        public IActionResult _LessonList(string year, string period)
        {
            var studentId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
               .Select(c => c.Value).SingleOrDefault();

            ViewBag.StudentId = Convert.ToInt32(studentId);
            var list = _lessonService.LessonListForTeacher(year, period, Convert.ToInt32(studentId));

            return View(list);
        }
        public IActionResult ListHomeworksForStudent(int id)
        {
            return View(_lessonService.GetHomeworksForLesson(id));
        }
        //public IActionResult _LessonList(string year, string period)
        //{
        //    var teacherId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
        //       .Select(c => c.Value).SingleOrDefault();
        //    var list = _lessonService.LessonListForTeacher(year, period, Convert.ToInt32(teacherId));
        //    return View(list);
        //}
    }
}
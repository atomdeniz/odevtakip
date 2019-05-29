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

        public IActionResult ListStudentForLesson(int lessonid)
        {
            _lessonService.
            return View();
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
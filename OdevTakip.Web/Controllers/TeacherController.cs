using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdevTakip.Business.Services.Interfaces;
using OdevTakip.Data.Model;
using OdevTakip.Web.Models;

namespace OdevTakip.Web.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController : Controller
    {
        
     
        private ILessonService _lessonService;
        public TeacherController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddLesson(LessonDTO lessonDTO)
        {
            var teacherId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
               .Select(c => c.Value).SingleOrDefault();
            var lesson = new Lesson
            {
                Name = lessonDTO.Lesson,
                Period = lessonDTO.Period,
                TeacherId = Convert.ToInt32(teacherId),
                Year = lessonDTO.Year
            };
            _lessonService.AddLesson(lesson);
            return RedirectToAction("Index");
        }
        public IActionResult _LessonList(string year,string period)
        {
            var teacherId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
               .Select(c => c.Value).SingleOrDefault();

             
              var list = _lessonService.LessonListForTeacher(year, period, Convert.ToInt32(teacherId));
            return View(list);
        }
    }
}
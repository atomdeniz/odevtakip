using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OdevTakip.Business.Services.Interfaces;

namespace OdevTakip.Web.Controllers
{
    public class LessonController : Controller
    {
        private ILessonService _lessonService;
        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }
        public IActionResult Index(int id)
        {
            return View(_lessonService.GetHomeworksForLesson(id));
        }

        public IActionResult AddHomework(string name,int id)
        {
            _lessonService.AddHomework(id, name);
            return Ok();
        }
        public IActionResult AddStudent(string number,int id)
        {
            _lessonService.AddStudentForLesson(number, id);
            return Ok();
        }

    }
}
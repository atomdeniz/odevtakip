using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OdevTakip.Business.Services.Interfaces;
using OdevTakip.Data.Model;
using OdevTakip.Web.Models;

namespace OdevTakip.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public const string SessionEmail = "_Email";
        public const string SessionId = "_Id";
        private ITeacherService _teacherService;
        private IStudentService _studentService;
        public AccountController(ITeacherService teacherService, IStudentService studentService)
        {
            _teacherService = teacherService;
            _studentService = studentService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserDto userdto)
        {

            if (userdto.OptRadio == "ogrenci")
            {
                var student = new Student();
                student.CreatedDate = userdto.CreatedDate;
                student.Email = userdto.Email + "@ogr.duzce.edu.tr";
                student.FirstName = userdto.FirstName;
                student.LastName = userdto.LastName;
                student.Password = userdto.Password;
                student.CreatedDate = DateTime.Now;
                student.SchoolNumber = userdto.SchoolNumber;
                _studentService.AddStudent(student);
            }
            else
            {
                var teacher = new Teacher();
                teacher.CreatedDate = userdto.CreatedDate;
                teacher.Email = userdto.Email + "@duzce.edu.tr";
                teacher.FirstName = userdto.FirstName;
                teacher.LastName = userdto.LastName;
                teacher.Password = userdto.Password;
                teacher.CreatedDate = DateTime.Now;
                _teacherService.AddTeacher(teacher);
            }
            return RedirectToAction("Login");
        }
        public IActionResult Register()
        {
            return View();
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {

            var teacher = _teacherService.GetTeacherWithLogin(loginDto.Email + "@duzce.edu.tr", loginDto.Password);
            var student = _studentService.GetStudentWithLogin(loginDto.Email + "@ogr.duzce.edu.tr", loginDto.Password);
            if (teacher != null)
            {
                ClaimsIdentity identity = null;
                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, loginDto.Email),
                    new Claim(ClaimTypes.Role, "Teacher"),
                    new Claim(ClaimTypes.NameIdentifier,teacher.Id.ToString())
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Teacher");
            }
            else if (student != null)
            {
                ClaimsIdentity identity = null;
                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, loginDto.Email),
                    new Claim(ClaimTypes.Role, "Student"),
                    new Claim(ClaimTypes.NameIdentifier,student.Id.ToString())
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Student");

            }
            else
            {
                return RedirectToAction("Login");
            }    
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync().Wait();

            return RedirectToAction("Login");
        }
        public IActionResult Username()
        {
            return Content("deniz");

        }
    }
}
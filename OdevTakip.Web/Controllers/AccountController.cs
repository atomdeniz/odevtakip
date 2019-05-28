using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OdevTakip.Business.Services.Interfaces;
using OdevTakip.Data.Model;

namespace OdevTakip.Web.Controllers
{
    public class AccountController : Controller
    {

        private IUserService service;
        public AccountController(IUserService service)
        {
            this.service = service;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            service.AddUser(user);
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
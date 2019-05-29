using OdevTakip.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdevTakip.Business.Services.Interfaces
{
    public interface ITeacherService
    {
        void AddTeacher(Teacher user);

        Teacher GetTeacherWithLogin(string Email, string Password);
    }
}

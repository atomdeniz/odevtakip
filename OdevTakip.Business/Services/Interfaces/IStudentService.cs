using OdevTakip.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdevTakip.Business.Services.Interfaces
{
    public interface IStudentService
    {
        void AddStudent(Student user);

        Student GetStudentWithLogin(string Email, string Password);
    }
}

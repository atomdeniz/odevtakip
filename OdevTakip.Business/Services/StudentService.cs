using OdevTakip.Business.Repositories;
using OdevTakip.Business.Services.Interfaces;
using OdevTakip.Business.UnitOfWork;
using OdevTakip.Data;
using OdevTakip.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdevTakip.Business.Services
{
    public class StudentService : IStudentService
    {
        private OdevTakipContext _dbContext;

        private IUnitOfWork _uow;
        private IRepository<Student> _studentRepository;

        public StudentService()
        {
            _dbContext = new OdevTakipContext();
            _uow = new OdevTakipUnitOfWork(_dbContext);
            _studentRepository = new OdevTakipRepository<Student>(_dbContext);
        }

        public void AddStudent(Student student)
        {
            _studentRepository.Add(student);
            _uow.SaveChanges();
        }

        public Student GetStudentWithLogin(string Email, string Password)
        {
            return _studentRepository.Get(x => x.Email == Email && x.Password == Password);
        }
    }


}

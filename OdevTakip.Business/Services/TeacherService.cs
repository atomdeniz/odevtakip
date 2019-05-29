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
    public class TeacherService : ITeacherService
    {
        private OdevTakipContext _dbContext;

        private IUnitOfWork _uow;
        private IRepository<Teacher> _teacherRepository;

        public TeacherService()
        {
            _dbContext = new OdevTakipContext();
            _uow = new OdevTakipUnitOfWork(_dbContext);
            _teacherRepository = new OdevTakipRepository<Teacher>(_dbContext);
        }

        public void AddTeacher(Teacher teacher)
        {
            _teacherRepository.Add(teacher);
            _uow.SaveChanges();
        }

        public Teacher GetTeacherWithLogin(string Email, string Password)
        {
            return _teacherRepository.Get(x => x.Email == Email && x.Password == Password);
        }
    }
}

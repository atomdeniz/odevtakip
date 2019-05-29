using OdevTakip.Business.Repositories;
using OdevTakip.Business.Services.Interfaces;
using OdevTakip.Business.UnitOfWork;
using OdevTakip.Data;
using OdevTakip.Data.Model;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace OdevTakip.Business.Services
{
    public class LessonService : ILessonService
    {
        private OdevTakipContext _dbContext;

        private IUnitOfWork _uow;
        private IRepository<Lesson> _lessonRepository;
        private IRepository<Homework> _homeworkRepository;
        private IRepository<Student> _studentRepository;
        public LessonService()
        {
            _dbContext = new OdevTakipContext();
            _uow = new OdevTakipUnitOfWork(_dbContext);
            _lessonRepository = new OdevTakipRepository<Lesson>(_dbContext);
            _homeworkRepository = new OdevTakipRepository<Homework>(_dbContext);
            _studentRepository= new OdevTakipRepository<Student>(_dbContext);
        }

        public void AddLesson(Lesson lesson)
        {
            _lessonRepository.Add(lesson);
            _uow.SaveChanges();
        }

        public List<Lesson> LessonListForTeacher(string year, string period, int teacherId)
        {
            return _lessonRepository.GetAll(x => x.TeacherId == teacherId && x.Period == period && x.Year == year).ToList();
        }

        public List<Homework> GetHomeworksForLesson(int lessonid)
        {
            return _homeworkRepository.GetAll(x=>x.LessonId ==lessonid).ToList();
        }

        public void AddHomework(int lessonid, string name)
        {
            Homework homework = new Homework();
            homework.LessonId = lessonid;
            homework.Name = name;
            homework.Active = true;
            homework.CreatedDate = DateTime.Now;
            _homeworkRepository.Add(homework);
            _uow.SaveChanges();
        }

        public List<Student> ListStudentForLesson(int lessonid) {
            return _studentRepository.GetAll(x => x.StudentLessons.All(y => y.LessonId == lessonid)).ToList();
        }


    }
}

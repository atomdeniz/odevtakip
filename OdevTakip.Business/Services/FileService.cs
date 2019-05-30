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
    class FileService: IFileService
    {
        private OdevTakipContext _dbContext;

        private IUnitOfWork _uow;
        private IRepository<File> _fileRepository;
        private IRepository<Homework> _homeworkRepository;
        private IRepository<Student> _studentRepository;

        public FileService()
        {
            _dbContext = new OdevTakipContext();
            _uow = new OdevTakipUnitOfWork(_dbContext);
            _fileRepository = new OdevTakipRepository<File>(_dbContext);
            _homeworkRepository = new OdevTakipRepository<Homework>(_dbContext);
            _studentRepository = new OdevTakipRepository<Student>(_dbContext);

        }
        public void
    }
}

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
    public class UserService : IUserService
    {
        private OdevTakipContext _dbContext;

        private IUnitOfWork _uow;
        private IRepository<User> _userRepository;

        public UserService()
        {
            _dbContext = new OdevTakipContext();
            _uow = new OdevTakipUnitOfWork(_dbContext);
            _userRepository = new OdevTakipRepository<User>(_dbContext);
        }

        public void AddUser(User user)
        {
            _userRepository.Add(user);
            _uow.SaveChanges();
        }
    }
}

using OdevTakip.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdevTakip.Business.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        int SaveChanges();
    }
}

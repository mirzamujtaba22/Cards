using Cards.Application.IUnitOfWork;
using Cards.Domain.Entities;
using Cards.Infrastructure;
using Cards.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork.IUnitOfWork
    {

        private readonly CardsDbContext _context;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(CardsDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            // Rollback changes if needed
        }

        public IRepository<T> GetRepository<T>()
        {
            if (_repositories.ContainsKey(typeof(IEntity)))
            {
                return (IRepository<T>)_repositories[typeof(IEntity)];
            }

            var repository = new CardRepository(_context);
            _repositories.Add(typeof(IEntity), repository);
            return (IRepository<T>)repository;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

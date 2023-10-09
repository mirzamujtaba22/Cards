using Cards.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards.Application.IUnitOfWork;

namespace Cards.Infrastructure.Persistence.Repositories
{
    public class CardRepository : IRepository<Card>
    {
        private readonly CardsDbContext _context;
        private readonly DbSet<Card> _dbSet;

        public CardRepository(CardsDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Card>();
        }

        public void Add(Card entity)
        {
            _dbSet.Add(entity);
        }
        public async Task<int> Delete(int id)
        {
            var row = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
           if (row != null)
            {
                _dbSet.Remove(row);
                return 1;
            }
            return 0;
        }

        public async Task<List<Card>> GetAll()
        {
            return await _dbSet.ToListAsync();
    }

        public async Task<Card?> GetById(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(Card entity)
        {
            _context.Update(entity);
        }
    }
}
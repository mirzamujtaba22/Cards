using Cards.Domain.Entities;
using Cards.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Application.CardService
{
    public class CardService : ICardService
    {
        private readonly CardsDbContext _db;
        public CardService(CardsDbContext cardsDbContext)
        {
                _db= cardsDbContext;
        }
        public async Task<Card> AddAsync(Card card)
        {
            card.Id = new int();
            await _db.Cards.AddAsync(card);
            await _db.SaveChangesAsync();
            return card;
        }

        public async Task <int> DeleteAsync(int cardId)
        {
            var existingcard = await _db.Cards.FirstOrDefaultAsync(x => x.Id == cardId);
            if (existingcard != null)
            {
                _db.Remove(existingcard);

                return await _db.SaveChangesAsync();

            }
            return 0;
        }

        public Task<List<Card>> GetAllAsync() => _db.Cards.ToListAsync();
        

        public async Task<Card> GetByID(int cardId) => await _db.Cards.FirstAsync(x => x.Id == cardId);
        public async Task<Card> UpdateAsync(Card card)
        {
            var existingcard = await _db.Cards.FirstOrDefaultAsync(x => x.Id == card.Id);
            if (existingcard != null)
            {
                existingcard.CardholderName = card.CardholderName;
                existingcard.CardNumberr = card.CardNumberr;
                existingcard.ExpiryMonth = card.ExpiryMonth;
                existingcard.ExpiryYear = card.ExpiryYear;
                existingcard.CVC = card.CVC;

                await _db.SaveChangesAsync();

               
            }
            return existingcard!;

        }
    }
}

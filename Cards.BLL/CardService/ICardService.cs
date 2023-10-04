using Cards.Domain.Entities;


namespace Cards.Application.CardService
{
    public interface ICardService
    {
        public Task<Card> AddAsync(Card card);
        public Task<Card> UpdateAsync(Card card);
        public Task<int> DeleteAsync(int cardId);
        public Task<Card> GetByID(int cardId);
        public Task<List<Card>> GetAllAsync();
    }
}

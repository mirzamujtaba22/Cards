using Cards.Domain.Entities;


namespace Cards.Application.CardService
{
    public interface ICardService
    {
        public void AddAsync(Card card);
        public Card Update(Card card);
        public Task<int> DeleteAsync(int cardId);
        public Task<Card?> GetByID(int cardId);
        public Task<List<Card>> GetAllAsync();
    }
}

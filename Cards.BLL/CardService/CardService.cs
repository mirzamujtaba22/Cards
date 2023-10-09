using Cards.Application.IUnitOfWork;
using Cards.Domain.Entities;

namespace Cards.Application.CardService
{
    public class CardService : ICardService
    {
        private readonly IUnitOfWork.IUnitOfWork _unitOfWork;
        private readonly IRepository<Card> _cardsRepository;
        public CardService(IUnitOfWork.IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _cardsRepository = _unitOfWork.GetRepository<Card>();
        }
        public void AddAsync(Card card)
        {
            _cardsRepository.Add(card);
            _unitOfWork.Commit();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var numberOfRow = await _cardsRepository.Delete(id);
            if (numberOfRow < 0)
            {
                _unitOfWork.Commit();
            }
            return numberOfRow;

        }



        public Task<List<Card>> GetAllAsync()
        {
           return _cardsRepository.GetAll();
        }
        public Task<Card?> GetByID(int cardId)
        {
            return _cardsRepository.GetById(cardId);
        }
        public Card Update(Card card)
        {
           
           _cardsRepository.Update(card);
            _unitOfWork.Commit();
            return card;
            
        }
    }
}






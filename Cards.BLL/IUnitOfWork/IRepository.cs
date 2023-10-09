using Cards.Domain.Entities;

namespace Cards.Application.IUnitOfWork
{
    public interface IRepository<T>

    {
        public Task<T?> GetById(int id);
        public void Add(T card);
        public void Update(T card);
        public Task<List<T>> GetAll();
        Task<int> Delete(int id);
    } 
}
using Said_Store.Domain.Entities;

namespace Said_Store.Application.Repositories
{
    public interface IBuyerRepository : IBaseRepository<Buyer>
    {
        Task<Buyer> GetByEmailAsync(string email, CancellationToken cancellationToken);
        public Task<Book> GetWholeByIdAsync(int id, CancellationToken cancellationToken);
        public Task<IEnumerable<Buyer>> GetWholeAsync(CancellationToken cancellationToken);

    }
}

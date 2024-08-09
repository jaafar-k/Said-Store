using Said_Store.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Said_Store.Application.Repositories
{
    internal interface InterfaceBuyerService
    {
        Task<IEnumerable<Buyer>> GetAllBuyersAsync();
        Task<Buyer?> GetBuyerByIdAsync(int id);
        Task<Buyer> AddBuyerAsync(Buyer buyer);
        Task<Buyer?> UpdateBuyerAsync(int id, Buyer buyer);
        Task<bool> DeleteBuyerAsync(int id);
    }
}

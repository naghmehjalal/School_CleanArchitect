using Core.Domain.Entities.Ent_Wallet;

namespace Core.Application.Contracts.Persistence.Interface_Wallet
{
    public interface IWalletRepository : IGenericRepository<Wallet>
    {
      
        Task<int> BalanceUserWallet(string userId);
        Task<List<Wallet>> GetWalletUser(string userId);
        Task<int> ChargeWallet(string userName, int amount, string description, bool isPay = false);

    }
}

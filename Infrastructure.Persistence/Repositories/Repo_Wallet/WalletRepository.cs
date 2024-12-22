using Core.Application.Contracts.Persistence.Interface_Wallet;
using Core.Domain.Entities.Ent_Wallet;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Repo_Wallet
{
    public class WalletRepository : GenericRepository<Wallet> , IWalletRepository
    {

        private readonly AppContext _dbcontext;

        public WalletRepository(AppContext dbContext)
            : base(dbContext)
        {
            _dbcontext = dbContext;

        }

        public async Task<int> BalanceUserWallet(string userId)
        {
            var enter = await _dbcontext.Wallets
               .Where(w => w.UserId == userId && w.TypeId == 1 && w.IsPay)
            .Select(w => w.Amount).ToListAsync();

            var exit = await _dbcontext.Wallets
                .Where(w => w.UserId == userId && w.TypeId == 2)
                .Select(w => w.Amount).ToListAsync();

            return (enter.Sum() - exit.Sum());
        }

        public async Task<int> ChargeWallet(string userId, int amount, string description, bool isPay = false)
        {
            Wallet wallet = new Wallet()
            {
                Amount = amount,
                CreateDate = DateTime.Now,
                Description = description,
                IsPay = isPay,
                TypeId = 1,
                UserId = userId
            };

            var obj =await AddAsync(wallet);

            if (obj == null)
                throw new Exception();

            return obj.WalletId;
        }

        public async Task<List<Wallet>> GetWalletUser(string userId)
        {

            return await _dbcontext.Wallets
                .Where(w => w.IsPay && w.UserId == userId)
                .Select(w => new Wallet()
                {
                    Amount = w.Amount,
                    CreateDate = w.CreateDate,
                    Description = w.Description,
                    IsPay = w.IsPay,
                    TypeId = w.TypeId
                })
                .ToListAsync();
        }
    }
}

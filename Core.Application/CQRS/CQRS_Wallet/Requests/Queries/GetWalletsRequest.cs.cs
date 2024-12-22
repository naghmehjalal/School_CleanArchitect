using Core.Application.DTOs.Wallet;
using MediatR;

namespace Core.Application.CQRS.CQRS_Wallet.Requests.Queries
{
    public class GetWalletsRequest : IRequest<List<WalletDTO>>
    {
        public int TypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

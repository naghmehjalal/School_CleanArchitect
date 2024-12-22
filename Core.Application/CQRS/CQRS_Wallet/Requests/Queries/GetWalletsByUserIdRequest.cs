using Core.Application.DTOs.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.CQRS.CQRS_Wallet.Requests.Queries
{
    public class GetWalletsByUserIdRequest : IRequest<List<WalletDTO>>
    {
        public required string UserId { get; set; }
   
    }
}

using Core.Application.DTOs.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.CQRS.CQRS_Wallet.Requests.Commands
{
    public class ChargeWalletRequest :IRequest<int>
    {
        public required CreateWalletDTO createWalletDTO { get; set; }
    }
}

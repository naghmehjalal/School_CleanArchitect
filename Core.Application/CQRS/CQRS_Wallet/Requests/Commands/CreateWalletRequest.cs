using Core.Application.DTOs.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.CQRS.CQRS_Wallet.Requests.Commands
{
    public class CreateWalletRequest :IRequest<int>
    {
        public CreateWalletDTO createWalletDTO { get; set; }
    }
}

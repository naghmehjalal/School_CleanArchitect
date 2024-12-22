using AutoMapper;
using Core.Application.Contracts.Persistence.Interface_Course;
using Core.Application.Contracts.Persistence.Interface_Wallet;
using Core.Application.CQRS.CQRS_Wallet.Requests.Commands;
using Core.Application.DTOs.Wallet;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.CQRS.CQRS_Wallet.Handlers.Commands
{
    public class ChargeWalletRequestHandler : IRequestHandler<ChargeWalletRequest, int>
    {

        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;
        public ChargeWalletRequestHandler(IWalletRepository walletRepository, IMapper mapper)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
        }

        public Task<int> Handle(ChargeWalletRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

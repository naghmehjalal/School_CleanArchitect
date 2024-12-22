using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.DTOs.Wallet
{
    public interface IWalletDTO
    {
        public int WalletId { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public bool IsPay { get; set; }
        public string UserId { get; set; }
        public int TypeId { get; set; }
    }
}

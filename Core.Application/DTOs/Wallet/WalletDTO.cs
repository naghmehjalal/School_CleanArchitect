using Core.Domain.Entities.Ent_Wallet;
using Infrastructure.Identity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.DTOs.Wallet
{
    public class WalletDTO :IWalletDTO
    {
        public int WalletId { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public bool IsPay { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserId { get; set; }
        public int TypeId { get; set; }
    }
}

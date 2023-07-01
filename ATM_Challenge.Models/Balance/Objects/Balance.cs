using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Challenge.Models.Balance.Objects
{
    public class Balance
    {
        public long IdBalance { get; set; }
        public long IdCard { get; set; }
        public DateTime? RegDate { get; set; }
        public decimal Amount { get; set; }
        public Balance() { }
        public Balance(DTO.Entities.Balance balance)
        {
            this.IdBalance = balance.IdBalance;
            this.IdCard = balance.IdCard;
            this.RegDate = balance.RegDate;
            this.Amount = balance.Amount;
        }
    }
}

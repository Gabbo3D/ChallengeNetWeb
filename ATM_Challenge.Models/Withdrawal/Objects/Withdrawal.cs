using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Challenge.Models.Withdrawal.Objects
{
    public class Withdrawal
    {
        public long IdWithdrawal { get; set; }
        public long IdCard { get; set; }
        public DateTime? RegDate { get; set; }
        public decimal Amount { get; set; }
        public Withdrawal(Withdrawal withdrawal) { }
        public Withdrawal(DTO.Entities.Withdrawal withdrawal)
        {
            this.IdWithdrawal = withdrawal.IdWithdrawal;
            this.IdCard = withdrawal.IdCard;
            this.RegDate = withdrawal.RegDate;
            this.Amount = withdrawal.Amount;
        }
    }
}

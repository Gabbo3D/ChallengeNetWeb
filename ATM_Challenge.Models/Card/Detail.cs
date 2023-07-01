using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Challenge.Models.Card
{
    public class Detail
    {
        public Objects.Card Card { get; set; }
        public IEnumerable<Models.Balance.Objects.Balance> Balances { get; set; }
        public IEnumerable<Models.Withdrawal.Objects.Withdrawal> Withdrawals { get; set; }
    }
}

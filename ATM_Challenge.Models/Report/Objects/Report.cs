using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Challenge.Models.Report.Objects
{
    public class Report
    {
        public Models.Card.Objects.Card Card { get; set; }
        public Models.Balance.Objects.Balance Balance { get; set; }
        public Models.Withdrawal.Objects.Withdrawal Withdrawal { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Challenge.Business.Clasess
{
    public class Report
    {
        public static Models.Report.Objects.Report Get(Models.Shared.RequestById request)
        {
            Models.Report.Objects.Report Report=new();
            Report.Card= new(DataAccess.Classes.Card.Get(request.Id.Value));
            Report.Balance= new(DataAccess.Classes.Balance.GetByIdCard(request.Id.Value));
            Report.Withdrawal = new(DataAccess.Classes.Withdrawal.GetByIdCard(request.Id.Value));
            return Report;
        }
    }
}

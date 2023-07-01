using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Challenge.DataAccess.Classes
{
    public class Withdrawal
    {
        public static DTO.Withdrawal Get(long WithdrawalId)
        {
            return Common.DataContext.WithdrawalSet.Find(WithdrawalId);
        }
        public static IEnumerable<DTO.Withdrawal> GetAll()
        {
            return Common.DataContext.WithdrawalSet.OrderBy(x => x.IdCard);
        }
        /*public static IEnumerable<DTO.Withdrawal> GetAllfor1(int? 1Id)
        {
            IQueryable<DTO.Withdrawal> query = Common.DataContext.Withdrawals;
            if (1Id.HasValue)
            {
                query = query.Where(x => x.1s.Any(y => y.1Id == 1Id.Value));
            }
            return query.OrderBy(x => x.WithdrawalId);
        }*/
        ///---SET
        public static void Delete(DTO.Withdrawal withdrawal)
        {
           Common.DataContext.WithdrawalSet.Remove(Common.DataContext.WithdrawalSet.Find(withdrawal.IdWithdrawal));
        }
    }
}

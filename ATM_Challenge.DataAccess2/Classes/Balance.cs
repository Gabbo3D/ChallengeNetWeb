using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Challenge.DataAccess.Classes
{
    public class Balance 
    {
        public static DTO.Balance Get(long IdBalance)
        {
            return Common.DataContext.BalanceSet.Find(IdBalance);
        }
        public static IEnumerable<DTO.Balance> GetAll()
        {
            return Common.DataContext.BalanceSet.OrderBy(x => x.IdCard);
        }
        /*public static IEnumerable<DTO.Balance> GetAllfor1(int? 1Id)
        {
            IQueryable<DTO.Balance> query = Common.DataContext.Balances;
            if (1Id.HasValue)
            {
                query = query.Where(x => x.1s.Any(y => y.1Id == 1Id.Value));
            }
            return query.OrderBy(x => x.BalanceId);
        }*/
        ///---SET
        public static void Delete(DTO.Balance balance)
        {
           Common.DataContext.BalanceSet.Remove(Common.DataContext.BalanceSet.Find(balance.IdBalance));
        }
    }
}

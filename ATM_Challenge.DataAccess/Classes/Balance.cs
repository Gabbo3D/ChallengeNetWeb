using ATM_Challenge.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Challenge.DataAccess.Classes
{
    public class Balance 
    {
        public static DTO.Entities.Balance Get(long IdBalance)
        {
            return DTO.Services.BalanceService.GetBalance(IdBalance);
        }
        public static DTO.Entities.Balance GetByIdCard(long IdCard)
        {
            return DTO.Services.BalanceService.GetByIdCard(IdCard);
        }
        public static IEnumerable<DTO.Entities.Balance> GetAll()
        {
            return DTO.Services.BalanceService.GetBalances();
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
        public static void Delete(DTO.Entities.Balance balance)
        {
            DTO.Services.BalanceService.DeleteBalance(balance.IdBalance);
        }
    }
}

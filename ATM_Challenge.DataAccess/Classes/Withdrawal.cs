using ATM_Challenge.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Challenge.DataAccess.Classes
{
    public class Withdrawal 
    {
        public static DTO.Entities.Withdrawal Get(long IdWithdrawal)
        {
            return DTO.Services.WithdrawalService.GetWithdrawal(IdWithdrawal);
        }
        public static DTO.Entities.Withdrawal GetByIdCard(long IdCard)
        {
            return DTO.Services.WithdrawalService.GetByIdCard(IdCard);
        }
        public static IEnumerable<DTO.Entities.Withdrawal> GetAll()
        {
            return DTO.Services.WithdrawalService.GetWithdrawals();
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
        public static void Delete(DTO.Entities.Withdrawal balance)
        {
            DTO.Services.WithdrawalService.DeleteWithdrawal(balance.IdWithdrawal);
        }
    }
}

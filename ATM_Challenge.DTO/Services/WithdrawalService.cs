using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using ATM_Challenge.DTO.Entities;

namespace ATM_Challenge.DTO.Services
{
    public class WithdrawalService
    {
        private static string _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=ATMdb;"; 
        public static List<Withdrawal> GetWithdrawals()
        {
            string sql = @"SELECT [IdWithdrawal]
                              ,[IdCard]
                              ,[RegDate]
                              ,[Amounbt]
                          FROM [WithdrawalSet] 
                          ORDER BY DueDate";            
            var db = new SqlConnection(_connectionString);//Iniciar la conexión con la base de datos
            var Withdrawals = db.Query<Withdrawal>(sql);//Ejecutar la consulta SQL y almacenar las líneas en nuestro modelo. 
            return Withdrawals.ToList();
        }

        public static Withdrawal GetWithdrawal(long idWithdrawal)
        {
            string sql = @"SELECT [IdWithdrawal]
                              ,[IdCard]
                              ,[RegDate]
                              ,[Amount]
                          FROM [WithdrawalSet] 
                          WHERE IdWithdrawal = @idWithdrawal";
            var db = new SqlConnection(_connectionString);
            var Withdrawal = db.QueryFirst<Withdrawal>(sql, new { idWithdrawal });
            return Withdrawal;
        }
        public static Withdrawal GetByIdCard(long idCard)
        {
            string sql = @"SELECT TOP 1
                               [IdWithdrawal]
                              ,[IdCard]
                              ,[RegDate]
                              ,[Amount]
                          FROM [WithdrawalSet] 
                          WHERE IdCard = @idCard ORDER BY RegDate desc"; 
            var db = new SqlConnection(_connectionString);
            var Withdrawal = db.QueryFirst<Withdrawal>(sql, new { idCard });
            return Withdrawal;
        }
        public static long CreateWithdrawal(Withdrawal Withdrawal)
        {
            string sql = @"INSERT INTO [WithdrawalSet] ([IdCard],[RegDate],[Amount])OUTPUT INSERTED.IdWithdrawal VALUES (@IdCard, @RegDate, @Amount);";
            //if (Withdrawal.IdWithdrawal == null|| Withdrawal.IdWithdrawal<=0) {
            //    sql = @"INSERT INTO WithdrawalSet(IdCard, RegDate, Amount) VALUES (@IdCard,@RegDate,@Amount);";
            //}
            var db = new SqlConnection(_connectionString);
            var id = db.QuerySingle<long>(sql, new
            {
                IdCard = Withdrawal.IdCard,
                RegDate = Withdrawal.RegDate,
                Amount = Withdrawal.Amount,
            });
            return Withdrawal.IdCard;
        }
        public static void UpdateWithdrawal(Withdrawal Withdrawal, int idWithdrawal)
        {
            string sql = @"UPDATE [WithdrawalSet] 
                           SET
                                [IdCard] = @idCard, 
                                [RegDate] = @regDate, 
                                [Amount] = @amount,
                           WHERE 
                                [IdWithdrawal] = @idWithdrawal";
            var db = new SqlConnection(_connectionString);
            db.Query(sql, new
            {
                idWithdrawal,
                Number = Withdrawal.IdCard,
                Pin = Withdrawal.RegDate,
                DueDate = Withdrawal.Amount,
            });
        }
        public static void DeleteWithdrawal(long idBalance)
        {
            string sql = @"DELETE FROM [BalanceSet] WHERE [IdBalance] = @idBalance";
            var db = new SqlConnection(_connectionString);
            db.Query(sql, new { idBalance });
        }
    }
}
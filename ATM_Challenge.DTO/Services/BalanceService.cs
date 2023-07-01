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
    public class BalanceService
    {
        private static string _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=ATMdb;"; 
        public static List<Balance> GetBalances()
        {
            string sql = @"SELECT [IdBalance]
                              ,[IdCard]
                              ,[RegDate]
                              ,[Amounbt]
                          FROM [BalanceSet] 
                          ORDER BY DueDate";            
            var db = new SqlConnection(_connectionString);//Iniciar la conexión con la base de datos
            var Balances = db.Query<Balance>(sql);//Ejecutar la consulta SQL y almacenar las líneas en nuestro modelo. 
            return Balances.ToList();
        }

        public static Balance GetBalance(long idBalance)
        {
            string sql = @"SELECT [IdBalance]
                              ,[IdCard]
                              ,[RegDate]
                              ,[Amount]
                          FROM [BalanceSet] 
                          WHERE IdBalance = @idBalance";
            var db = new SqlConnection(_connectionString);
            var Balance = db.QueryFirst<Balance>(sql, new { idBalance });
            return Balance;
        }
        public static Balance GetByIdCard(long idCard)
        {
            string sql = @"SELECT TOP 1
                               [IdBalance]
                              ,[IdCard]
                              ,[RegDate]
                              ,[Amount]
                          FROM [BalanceSet] 
                          WHERE IdCard = @idCard ORDER BY RegDate desc"; 
            var db = new SqlConnection(_connectionString);
            var Balance = db.QueryFirst<Balance>(sql, new { idCard });
            return Balance;
        }
        public static long CreateBalance(Balance Balance)
        {
            string sql = @"INSERT INTO [BalanceSet] ([IdCard],[RegDate],[Amount])OUTPUT INSERTED.IdBalance VALUES (@IdCard, @RegDate, @Amount);";
            //if (Balance.IdBalance == null|| Balance.IdBalance<=0) {
            //    sql = @"INSERT INTO BalanceSet(IdCard, RegDate, Amount) VALUES (@IdCard,@RegDate,@Amount);";
            //}
            var db = new SqlConnection(_connectionString);
            var id = db.QuerySingle<long>(sql, new
            {
                IdCard = Balance.IdCard,
                RegDate = Balance.RegDate,
                Amount = Balance.Amount,
            });
            return Balance.IdCard;
        }
        public static void UpdateBalance(Balance Balance, int idBalance)
        {
            string sql = @"UPDATE [BalanceSet] 
                           SET
                                [IdCard] = @idCard, 
                                [RegDate] = @regDate, 
                                [Amount] = @amount,
                           WHERE 
                                [IdBalance] = @idBalance";
            var db = new SqlConnection(_connectionString);
            db.Query(sql, new
            {
                idBalance,
                Number = Balance.IdCard,
                Pin = Balance.RegDate,
                DueDate = Balance.Amount,
            });
        }
        public static void DeleteBalance(long idBalance)
        {
            string sql = @"DELETE FROM [BalanceSet] WHERE [IdBalance] = @idBalance";
            var db = new SqlConnection(_connectionString);
            db.Query(sql, new { idBalance });
        }
    }
}
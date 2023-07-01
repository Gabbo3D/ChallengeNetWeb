using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using ATM_Challenge.DTO.Entities;
using Microsoft.VisualBasic;

namespace ATM_Challenge.DTO.Services
{
    public class CardService
    {
        private static string _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=ATMdb;"; 
        public static List<Card> GetCards()
        {
            string sql = @"SELECT [IdCard]
                              ,[Number]
                              ,[Pin]
                              ,[DueDate]
                              ,[Attempts]
                              ,[Lock]
                          FROM [CardSet] 
                          ORDER BY DueDate";            
            var db = new SqlConnection(_connectionString);//Iniciar la conexión con la base de datos
            var Cards = db.Query<Card>(sql);//Ejecutar la consulta SQL y almacenar las líneas en nuestro modelo. 
            return Cards.ToList();
        }

        public static Card GetCard(long idCard)
        {
            string sql = @"SELECT [IdCard]
                              ,[Number]
                              ,[Pin]
                              ,[DueDate]
                              ,[Attempts]
                              ,[Lock]
                          FROM [CardSet] 
                          WHERE IdCard = @idCard";
            var db = new SqlConnection(_connectionString);
            var Card = db.QueryFirst<Card>(sql, new { idCard });
            return Card;
        }
        public static Nullable<Int64> GetCardByNumer(string number)
        {
            Nullable<Int64> IdCard = 0;
            if (number.Length==18)
            {
                string sql = @"SELECT [IdCard]
                              ,[Number]
                              ,[Pin]
                              ,[DueDate]
                              ,[Attempts]
                              ,[Lock]
                          FROM [CardSet] 
                          WHERE Number = @number";
                var db = new SqlConnection(_connectionString);
                IdCard = db.QueryFirst<Card>(sql, new { number }).IdCard;
                
            }
            return IdCard;
        }
        public static long CreateCard(Card Card)
        {
            string sql = @"INSERT INTO [CardSet] ([Number],[Pin],[DueDate],[Attempts],[Lock])OUTPUT INSERTED.IdCard VALUES (@Number,@pin, @DueDate, @Attempts,@lock);";
            //if (Card.IdCard == null|| Card.IdCard<=0) {
            //    sql = @"INSERT INTO CardSet(IdCard, RegDate, Amount) VALUES (@IdCard,@RegDate,@Amount);";
            //}
            var db = new SqlConnection(_connectionString);
            var id = db.QuerySingle<long>(sql, new
            {
                Number = Card.Number,
                Pin = Card.Pin,
                DueDate = Card.DueDate,
                Attempts = Card.Attempts,
                Lock = Card.Lock,
            });
            return Card.IdCard;
        }
        public static void UpdateCard(Card Card, long idCard)
        {
            string sql = @"UPDATE [CardSet] 
                           SET
                                [Number] = @number, 
                                [Pin] = @pin, 
                                [DueDate] = @dueDate,
                                [Attempts] = @attempts, 
                                [Lock] = @lock 
                           WHERE 
                                [IdCard] = @idCard";
            var db = new SqlConnection(_connectionString);
            db.Query(sql, new
            {
                idCard,
                Number = Card.Number,
                Pin = Card.Pin,
                DueDate = Card.DueDate,
                Attempts = Card.Attempts,
                Lock = Card.Lock,
            });
        }
        public static void DeleteCard(long idCard)
        {
            string sql = @"DELETE FROM [CardSet] WHERE [IdCard] = @idCard";
            var db = new SqlConnection(_connectionString);
            db.Query(sql, new { idCard });
        }
    }
}
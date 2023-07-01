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

            //Iniciar la conexión con la base de datos
            var db = new SqlConnection(_connectionString);

            //Ejecutar la consulta SQL y almacenar las líneas en nuestro modelo. 
            var Cards = db.Query<Card>(sql);

            //Dapper devuelve un IEnumerable para trabajar más cómodos lo convertimos a listas. 
            return Cards.ToList();
        }

        public static Card GetCard(int id)
        {
            //En este caso tenemos que introducir un parametro para el Id,
            //NUNCA concatenes directamente la variable en el SQL porque puedes padecer inyecciones SQL
            string sql = @"SELECT [IdCard]
                              ,[Number]
                              ,[Pin]
                              ,[DueDate]
                              ,[Attempts]
                              ,[Lock]
                          FROM [CardSet] 
                          WHERE IdCard = @idCard";

            //Iniciar la conexión con la base de datos
            var db = new SqlConnection(_connectionString);

            //Ejecutar la consulta SQL y pasar los parametros en un objeto, como id se llama igual
            //en la variable que en el parametro no hace falta escribir id = id. 
            //Agregamos first para que solo nos devuelva una línea (obviamente solo va a haber una al buscar por id)
            var Card = db.QueryFirst<Card>(sql, new { id });

            //Devolvemos el objeto.
            return Card;
        }

        public static int CreateCard(Card Card)
        {
            //Generamos la consulta con sus correspondientes parametros, agregamos
            //OUTPUT para que nos devuelva el id del registro insertado.
            string sql = @"INSERT INTO [CardSet] ([Number],[Pin],[DueDate],[Attempts],[Lock])
                            OUTPUT INSERTED.IdCard
                           VALUES (@Number, @Pin, @DueDate,@Attempts, @Lock);";

            //Iniciar la conexión con la base de datos
            var db = new SqlConnection(_connectionString);

            //Mapeamos los parametros y ejecutamos la consulta.
            var id = db.QuerySingle<int>(sql, new
            {
                Number = Card.Number,
                Pin = Card.Pin,
                DueDate = Card.DueDate,
                Attempts = Card.Attempts,
                Lock = Card.Lock,
            });

            //Devolvemos el id del registro insertado
            return id;

        }
        public static void UpdateCard(Card Card, int id)
        {
            //Generamos la consulta con sus correspondientes parametros
            string sql = @"UPDATE [CardSet] 
                           SET
                                [Number] = @number, 
                                [Pin] = @pin, 
                                [DueDate] = @dueDate,
                                [Attempts] = @attempts 
                                [Lock] = @lock 
                           WHERE 
                                [IdCard] = @idCard";

            //Iniciar la conexión con la base de datos
            var db = new SqlConnection(_connectionString);

            //Mapeamos los parametros y ejecutamos la consulta.
            db.Query(sql, new
            {
                id,
                Number = Card.Number,
                Pin = Card.Pin,
                DueDate = Card.DueDate,
                Attempts = Card.Attempts,
                Lock = Card.Lock,
            });
        }

        public static void DeleteCard(int id)
        {
            //Generamos la consulta con sus correspondientes parametros
            string sql = @"DELETE FROM [CardSet]       
                           WHERE [IdCard] = @idCard";
            //Iniciar la conexión con la base de datos
            var db = new SqlConnection(_connectionString);
            //Mapeamos los parametros y ejecutamos la consulta.
            db.Query(sql, new { id });
        }


    }
}
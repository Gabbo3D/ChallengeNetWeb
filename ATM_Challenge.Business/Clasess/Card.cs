using ATM_Challenge.Models.Card;
using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Challenge.Business
{
    public class Card
    {
        public static Models.Card.Objects.Card Get(Models.Shared.RequestById request)
        {
            Models.Card.Objects.Card Card = new(DataAccess.Classes.Card.Get(request.Id.Value));
            Card.Balance = 0;
            Card.Balance = Business.Balance.GetByIdCard(request).Amount;
            Card.Withdrawal = 0;
            Card.Withdrawal = Business.Withdrawal.GetByIdCard(request).Amount;
            return Card;
        }
        public static Nullable<Int64> GetByNumber(string Number)
        {
            Models.Shared.RequestById request = new()
            {
                Id = DataAccess.Classes.Card.GetByNumber(Number)
            };   
            return request.Id;
        }
        public static IEnumerable<Models.Card.Objects.Card> GetAll()
        {
            IEnumerable<DTO.Entities.Card> Cards = DataAccess.Classes.Card.GetAll();
            return Cards.Select(x => new Models.Card.Objects.Card(x));
        }
        public static long Save(Edit request)
        {
            DTO.Entities.Card Card = new();
            if (request.IdCard.HasValue)
            {
                Card = DataAccess.Classes.Card.Get(request.IdCard.Value);
            }
            Card.IdCard = request.IdCard.Value;
            Card.Number = request.Number;
            //DataAccess.Classes.Generic.Save(Card);
            return Card.IdCard;
        }
        public static long Update(Edit request)
        {
            DTO.Entities.Card Card = new();
            if (request.IdCard.HasValue)
            {
                Card = DataAccess.Classes.Card.Get(request.IdCard.Value);
            }
            Card.IdCard = request.IdCard.Value;
            Card.Number = request.Number;
            Card.Pin = request.Pin;
            Card.DueDate = request.DueDate.Value;
            Card.Attempts = (short)request.Attempts;
            Card.Lock = request.Lock;
            DTO.Services.CardService.UpdateCard(Card, request.IdCard.Value);
            return Card.IdCard;
        }
        /*public static IEnumerable<Models.Card.Objects.Card> GetAllForMovie(int movieId)
        {
            //Models.Movie.Objects.Movie movie = new Models.Movie.Objects.Movie(  DataAccess.Movie.Get(movieId)   );
            IEnumerable<DTO.Card> Cards = DataAccess.Movie.Get(movieId).Cards;
            return Cards.Select(x => new Models.Card.Objects.Card(x));
        }
        public static IEnumerable<Models.Card.Objects.Card> Search(Models.Card.Objects.SearchFields searchFields)
        {
            IEnumerable<DTO.Entities.Card> Cards = DataAccess.Classes.Card.Search(searchFields.Keyword);
            List<Models.Card.Objects.Card> response = new();
            response.AddRange(Cards.Select(x => new Models.Card.Objects.Card(x)));
            return response;
        }*/
        //public static string GetName(int CardId)
        //{
        //    return DataAccess.Card.Get(CardId).Name;
        //}
        //public static List<string> GetList()
        //{
        //    return DataAccess.Card.GetList();
        //}
        //public static string GetObjString(int id)
        //{
        //    return DataAccess.Card.GetObjString(id);
        //}
        //public static string GetReferences(Models.Card CardView)
        //{
        //    var Card = new DTO.Card
        //    {
        //        CardId = CardView.ID,
        //        Name = CardView.Name,
        //        Birth = CardView.birth
        //    };
        //    return DataAccess.Card.GetReferences(Card);
        //}
        /////---SET

        /*public static Models.Card.Edit GetForEdit(int? CardId)
        {
            Models.Card.Edit response = new Models.Card.Edit();
            if (CardId.HasValue)
            {
                response = new Models.Card.Edit(Business.Card.Get(new Models.Shared.RequestById() { Id = CardId.Value }));
            }
            return response;
        }*/
        /*public static void Delete(Models.Shared.RequestById request)
        {
            DTO.Card Card = DataAccess.Card.Get(request.Id);
            foreach (DTO.Movy movie in DataAccess.Movie.GetAllforCard(request.Id))
            {
                Card.Movies.Remove(movie);
                movie.Cards.Remove(Card);
                DataAccess.Generic.Save(Card, false);
                DataAccess.Generic.Save(movie, false);
            }
            DataAccess.Card.Delete(Card);
            DataAccess.Generic.SaveChanges();
        }*/
    }
}

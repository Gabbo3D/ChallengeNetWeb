using ATM_Challenge.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Challenge.DataAccess.Classes
{
    public class Card
    {
        public static DTO.Entities.Card Get(long IdCard)
        {
            return DTO.Services.CardService.GetCard(IdCard);
        }
        public static Nullable<Int64> GetByNumber(string number)
        {
            return DTO.Services.CardService.GetCardByNumer(number);
        }
        public static IEnumerable<DTO.Entities.Card> GetAll()
        {
            return DTO.Services.CardService.GetCards();
        }
        /*public static IEnumerable<DTO.Card> GetAllfor1(int? 1Id)
        {
            IQueryable<DTO.Card> query = Common.DataContext.Cards;
            if (1Id.HasValue)
            {
                query = query.Where(x => x.1s.Any(y => y.1Id == 1Id.Value));
            }
            return query.OrderBy(x => x.cardId);
        }
        public static IEnumerable<DTO.Entities.Card> Search(string keyword)
        {
            IQueryable<DTO.Entities.Card> query = Common.DataContext.CardSet;
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Number.Contains(keyword));
            }
            return query.OrderBy(x => x.Number);
        }*/
        ///---SET
        public static void Delete(DTO.Entities.Card card)
        {
            DTO.Services.CardService.DeleteCard(card.IdCard);
        }
    }
}

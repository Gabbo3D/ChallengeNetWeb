using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Challenge.DataAccess.Classes
{
    public class Card
    {
        public static ATM_Challenge.DTO.Entities.Card Get(long IdCard)
        {
            return Common.DataContext.CardSet.Find(IdCard);
        }
        public static IEnumerable<DTO.Entities.Card> GetAll()
        {
            return Common.DataContext.CardSet.OrderBy(x => x.Number);
        }
        /*public static IEnumerable<DTO.Card> GetAllfor1(int? 1Id)
        {
            IQueryable<DTO.Card> query = Common.DataContext.Cards;
            if (1Id.HasValue)
            {
                query = query.Where(x => x.1s.Any(y => y.1Id == 1Id.Value));
            }
            return query.OrderBy(x => x.cardId);
        }*/
        public static IEnumerable<DTO.Entities.Card> Search(string keyword)
        {
            IQueryable<DTO.Entities.Card> query = Common.DataContext.CardSet;
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Number.Contains(keyword));
            }
            return query.OrderBy(x => x.Number);
        }
        ///---SET
        public static void Delete(DTO.Entities.Card card)
        {
           Common.DataContext.CardSet.Remove(Common.DataContext.CardSet.Find(card.IdCard));
        }
    }
}

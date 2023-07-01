using ATM_Challenge.Models.Balance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Challenge.Business
{
    public class Balance
    {
        public static Models.Balance.Objects.Balance Get(Models.Shared.RequestById request)
        {
            Models.Balance.Objects.Balance Balance = new(DataAccess.Classes.Balance.Get(request.Id.Value));
            return Balance;
        }
        public static Models.Balance.Objects.Balance GetByIdCard(Models.Shared.RequestById request)
        {
            Models.Balance.Objects.Balance Balance = new(DataAccess.Classes.Balance.GetByIdCard(request.Id.Value));
            return Balance;
        }
        public static IEnumerable<Models.Balance.Objects.Balance> GetAll()
        {
            IEnumerable<DTO.Entities.Balance> Balances = DataAccess.Classes.Balance.GetAll();
            return Balances.Select(x => new Models.Balance.Objects.Balance(x));
        }
        public static long Save(Edit request)
        {
            DTO.Entities.Balance Balance = new();
            if (request.IdBalance.HasValue)
            {
                Balance = DataAccess.Classes.Balance.Get(request.IdBalance.Value);
            }
            Balance.IdCard = request.IdCard;
            Balance.RegDate = request.RegDate.Value;
            Balance.Amount = request.Amount.Value;
            DTO.Services.BalanceService.CreateBalance(Balance);
            return Balance.IdCard;
        }
        /*public static IEnumerable<Models.Balance.Objects.Balance> GetAllForMovie(int movieId)
        {
            //Models.Movie.Objects.Movie movie = new Models.Movie.Objects.Movie(  DataAccess.Movie.Get(movieId)   );
            IEnumerable<DTO.Balance> Balances = DataAccess.Movie.Get(movieId).Balances;
            return Balances.Select(x => new Models.Balance.Objects.Balance(x));
        }*/
        //public static IEnumerable<Models.Balance.Objects.Balance> Search(Models.Balance.Objects.SearchFields searchFields)
        //{
        //    IEnumerable<DTO.Balance> Balances = DataAccess.Balance.Search(searchFields.Keyword);
        //    List<Models.Balance.Objects.Balance> response = new List<Models.Balance.Objects.Balance>();
        //    response.AddRange(Balances.Select(x => new Models.Balance.Objects.Balance(x)));
        //    return response;
        //}
        //public static string GetName(int BalanceId)
        //{
        //    return DataAccess.Balance.Get(BalanceId).Name;
        //}
        //public static List<string> GetList()
        //{
        //    return DataAccess.Balance.GetList();
        //}
        //public static string GetObjString(int id)
        //{
        //    return DataAccess.Balance.GetObjString(id);
        //}
        //public static string GetReferences(Models.Balance BalanceView)
        //{
        //    var Balance = new DTO.Balance
        //    {
        //        BalanceId = BalanceView.ID,
        //        Name = BalanceView.Name,
        //        Birth = BalanceView.birth
        //    };
        //    return DataAccess.Balance.GetReferences(Balance);
        //}
        /////---SET

        /*public static Models.Balance.Edit GetForEdit(int? BalanceId)
        {
            Models.Balance.Edit response = new Models.Balance.Edit();
            if (BalanceId.HasValue)
            {
                response = new Models.Balance.Edit(Business.Balance.Get(new Models.Shared.RequestById() { Id = BalanceId.Value }));
            }
            return response;
        }*/
        /*public static void Delete(Models.Shared.RequestById request)
        {
            DTO.Balance Balance = DataAccess.Balance.Get(request.Id);
            foreach (DTO.Movy movie in DataAccess.Movie.GetAllforBalance(request.Id))
            {
                Balance.Movies.Remove(movie);
                movie.Balances.Remove(Balance);
                DataAccess.Generic.Save(Balance, false);
                DataAccess.Generic.Save(movie, false);
            }
            DataAccess.Balance.Delete(Balance);
            DataAccess.Generic.SaveChanges();
        }*/
    }
}

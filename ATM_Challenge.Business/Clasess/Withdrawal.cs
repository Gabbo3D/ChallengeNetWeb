using ATM_Challenge.Models.Withdrawal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Challenge.Business
{
    public class Withdrawal
    {
        public static Models.Withdrawal.Objects.Withdrawal Get(Models.Shared.RequestById request)
        {
            Models.Withdrawal.Objects.Withdrawal Withdrawal = new(DataAccess.Classes.Withdrawal.Get(request.Id.Value));
            return Withdrawal;
        }
        public static Models.Withdrawal.Objects.Withdrawal GetByIdCard(Models.Shared.RequestById request)
        {
            Models.Withdrawal.Objects.Withdrawal Withdrawal = new(DataAccess.Classes.Withdrawal.GetByIdCard(request.Id.Value));
            return Withdrawal;
        }
        public static IEnumerable<Models.Withdrawal.Objects.Withdrawal> GetAll()
        {
            IEnumerable<DTO.Entities.Withdrawal> Withdrawals = DataAccess.Classes.Withdrawal.GetAll();
            return Withdrawals.Select(x => new Models.Withdrawal.Objects.Withdrawal(x));
        }
        public static long Save(Edit request)
        {
            DTO.Entities.Withdrawal Withdrawal = new();
            if (request.IdWithdrawal.HasValue)
            {
                Withdrawal = DataAccess.Classes.Withdrawal.Get(request.IdWithdrawal.Value);
            }
            Withdrawal.IdCard = request.IdCard;
            Withdrawal.RegDate = request.RegDate.Value;
            Withdrawal.Amount = request.Amount.Value;
            DTO.Services.WithdrawalService.CreateWithdrawal(Withdrawal);
            return Withdrawal.IdCard;
        }
        /*public static IEnumerable<Models.Withdrawal.Objects.Withdrawal> GetAllForMovie(int movieId)
        {
            //Models.Movie.Objects.Movie movie = new Models.Movie.Objects.Movie(  DataAccess.Movie.Get(movieId)   );
            IEnumerable<DTO.Withdrawal> Withdrawals = DataAccess.Movie.Get(movieId).Withdrawals;
            return Withdrawals.Select(x => new Models.Withdrawal.Objects.Withdrawal(x));
        }*/
        //public static IEnumerable<Models.Withdrawal.Objects.Withdrawal> Search(Models.Withdrawal.Objects.SearchFields searchFields)
        //{
        //    IEnumerable<DTO.Withdrawal> Withdrawals = DataAccess.Withdrawal.Search(searchFields.Keyword);
        //    List<Models.Withdrawal.Objects.Withdrawal> response = new List<Models.Withdrawal.Objects.Withdrawal>();
        //    response.AddRange(Withdrawals.Select(x => new Models.Withdrawal.Objects.Withdrawal(x)));
        //    return response;
        //}
        //public static string GetName(int WithdrawalId)
        //{
        //    return DataAccess.Withdrawal.Get(WithdrawalId).Name;
        //}
        //public static List<string> GetList()
        //{
        //    return DataAccess.Withdrawal.GetList();
        //}
        //public static string GetObjString(int id)
        //{
        //    return DataAccess.Withdrawal.GetObjString(id);
        //}
        //public static string GetReferences(Models.Withdrawal WithdrawalView)
        //{
        //    var Withdrawal = new DTO.Withdrawal
        //    {
        //        WithdrawalId = WithdrawalView.ID,
        //        Name = WithdrawalView.Name,
        //        Birth = WithdrawalView.birth
        //    };
        //    return DataAccess.Withdrawal.GetReferences(Withdrawal);
        //}
        /////---SET

        /*public static Models.Withdrawal.Edit GetForEdit(int? WithdrawalId)
        {
            Models.Withdrawal.Edit response = new Models.Withdrawal.Edit();
            if (WithdrawalId.HasValue)
            {
                response = new Models.Withdrawal.Edit(Business.Withdrawal.Get(new Models.Shared.RequestById() { Id = WithdrawalId.Value }));
            }
            return response;
        }*/
        /*public static void Delete(Models.Shared.RequestById request)
        {
            DTO.Withdrawal Withdrawal = DataAccess.Withdrawal.Get(request.Id);
            foreach (DTO.Movy movie in DataAccess.Movie.GetAllforWithdrawal(request.Id))
            {
                Withdrawal.Movies.Remove(movie);
                movie.Withdrawals.Remove(Withdrawal);
                DataAccess.Generic.Save(Withdrawal, false);
                DataAccess.Generic.Save(movie, false);
            }
            DataAccess.Withdrawal.Delete(Withdrawal);
            DataAccess.Generic.SaveChanges();
        }*/
    }
}

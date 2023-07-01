using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Challenge.Models.Withdrawal
{
    public class Edit
    {
        public long? IdWithdrawal { get; set; }
        //[StringLength(16, MinimumLength = 16)]
        //[Required(ErrorMessage ="Ingrese el título")]
        public long IdCard { get; set; }
        //[Display(Name = "Release Date")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? RegDate { get; set; }
        //[Range(1, 100)]
        //[DataType(DataType.Currency)]
        public decimal? Amount { get; set; }

        //public IEnumerable<Models.Card.Objects.Card> Cards { get; set; }

        public Edit() { }
        public Edit(Objects.Withdrawal withdrawal)
        {
            this.IdWithdrawal = withdrawal.IdWithdrawal;
            this.IdCard = withdrawal.IdCard;
            this.RegDate = withdrawal.RegDate;
            this.Amount = withdrawal.Amount;
        }
    }
}

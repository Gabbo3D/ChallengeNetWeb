using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Challenge.Models.Card
{
    public class Edit
    {
        public long? IdCard { get; set; }
        //[StringLength(16, MinimumLength = 16)]
        //[Required(ErrorMessage ="Ingrese el título")]
        public string Number { get; set; }
        public string Pin { get; set; }
        //[Display(Name = "Release Date")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DueDate { get; set; }
        public int Attempts { get; set; }
        public bool Lock { get; set; }

        public IEnumerable<Models.Card.Objects.Card> Cards { get; set; }

        public Edit() { }
        public Edit(Objects.Card card)
        {
            this.IdCard = card.IdCard;
            this.Number = card.Number;
            this.Pin = card.Pin;
            this.DueDate = card.DueDate;
            this.Attempts = card.Attempts;
            this.Lock = card.Lock;
        }
    }
}

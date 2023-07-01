using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Challenge.Models.Card.Objects
{
    public class Card
    {      
        public long IdCard { get; set; }
        public string Number { get; set; }
        public string Pin { get; set; }
        public DateTime? DueDate { get; set; }
        public int Attempts { get; set; }
        public bool Lock { get; set; }
        public decimal Balance { get; set; }
        public decimal Withdrawal { get; set; }
        public Card() { }
        public Card(DTO.Entities.Card card)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Challenge.Models.Card
{
    public class List
    {
        public Objects.SearchFields SearchFields { get; set; } = new Objects.SearchFields();
        public IEnumerable<Objects.Card>? Cards { get; set; }
    }
}

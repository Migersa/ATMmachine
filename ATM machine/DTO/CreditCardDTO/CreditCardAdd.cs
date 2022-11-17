using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.CreditCardDTO
{
    public class CreditCardAdd
    {

        public String CardNumber { get; set; } = null!;
        public String Pin { get; set; } = null!;
        public double? Balance { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}

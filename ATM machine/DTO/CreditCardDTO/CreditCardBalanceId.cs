using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.CreditCardDTO
{
    public class CreditCardBalanceId
    {

        public Guid CardId { get; set; }
      
        public double? Balance { get; set; }
    }
}

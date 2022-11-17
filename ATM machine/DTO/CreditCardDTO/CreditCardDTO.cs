using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.CreditCardDTO
{
    public class CreditCardDTO
    {

        public Guid CardId { get; set; }
        public byte[] CardNumber { get; set; } = null!;
        public byte[] Pin { get; set; } = null!;
        public double? Balance { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string NameOfOwner { get; set; } = null!;

    }
}

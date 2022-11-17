using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DepositDTO
{
    public class DepositDTO
    {
        public Guid DepositId { get; set; }
        public DateTime DateOfDeposit { get; set; }
        public byte[] CardNumber { get; set; } = null!;
        
        public Guid CardId { get; set; }
        public double? DepositValue { get; set; }


    }
}

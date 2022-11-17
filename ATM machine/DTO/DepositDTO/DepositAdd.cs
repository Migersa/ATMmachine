using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DepositDTO
{
    public class DepositAdd
    {

        public String CardNumber { get; set; } = null!;
    
        public Guid CardId { get; set; }
        public double? DepositValue { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.WithdrawDTO
{
   public class WithdrawAdd
    {

     
        public Guid CardId { get; set; }
        public double? WithdrawValue { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.WithdrawDTO
{
    public class WithdrawDTO
    {
        public Guid Id { get; set; }
        public DateTime DateofWithdraw { get; set; }
        public Guid CardId { get; set; }
        public double? WithdrawValue { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Deposit
    {
        public Guid DepositId { get; set; }
        public DateTime DateOfDeposit { get; set; }
        public byte[] CardNumber { get; set; } = null!;
        public Guid CardId { get; set; }
        public double? DepositValue { get; set; }

        public virtual CreditCard Card { get; set; } = null!;
    }
}

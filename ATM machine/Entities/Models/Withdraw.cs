using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Withdraw
    {
        public Guid Id { get; set; }
        public DateTime DateofWithdraw { get; set; }
        public Guid CardId { get; set; }
        public double? WithdrawValue { get; set; }

        public virtual CreditCard Card { get; set; } = null!;
    }
}

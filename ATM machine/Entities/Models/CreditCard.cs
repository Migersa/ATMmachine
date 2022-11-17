using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class CreditCard
    {
        public CreditCard()
        {
            Deposits = new HashSet<Deposit>();
            Withdraws = new HashSet<Withdraw>();
        }

        public Guid CardId { get; set; }
        public byte[] CardNumber { get; set; } = null!;
        public byte[] Pin { get; set; } = null!;
        public double? Balance { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string NameOfOwner { get; set; } = null!;

        public virtual ICollection<Deposit> Deposits { get; set; }
        public virtual ICollection<Withdraw> Withdraws { get; set; }
    }
}

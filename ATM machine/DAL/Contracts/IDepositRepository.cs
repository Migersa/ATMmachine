using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    
    
   public interface IDepositRepository : IRepository<Deposit, Guid>
    {

        Deposit addDeposit(Deposit deposit);
    }
    
}

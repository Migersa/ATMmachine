using DAL.Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    
    internal class DepositRepository : BaseRepository<Deposit, Guid>, IDepositRepository
    {
        public DepositRepository(ATMmachine5Context dbContext) : base(dbContext)
        {
        }


        public Deposit addDeposit(Deposit deposit)
        {
            deposit.DepositId = Guid.NewGuid();
            deposit.DateOfDeposit = DateTime.Now;
            context.Add(deposit);
            PersistChangesToTrackedEntities();
            return context.Add(deposit).Entity;



        }
    }
    
}

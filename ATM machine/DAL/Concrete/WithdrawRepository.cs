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
    
    internal class WithdrawRepository : BaseRepository<Withdraw, Guid>, IWithdrawRepository
    {
        public WithdrawRepository(ATMmachine5Context dbContext) : base(dbContext)
        {
        }



        public Withdraw addWithdraw(Withdraw withdraw)
        {
            withdraw.Id = Guid.NewGuid();
            withdraw.DateofWithdraw = DateTime.Now;
            context.Add(withdraw);
            PersistChangesToTrackedEntities();
            return context.Add(withdraw).Entity;



        }
    }
    
}

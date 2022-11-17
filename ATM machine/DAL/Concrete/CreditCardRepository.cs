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
    
    internal class CreditCardRepository : BaseRepository<CreditCard, Guid>, ICreditCardRepository
    {
        public CreditCardRepository(ATMmachine5Context dbContext) : base(dbContext)
        {
        }

        public CreditCard addCreditCard(CreditCard creditcard)
        {
            creditcard.CardId = Guid.NewGuid();

            context.Add(creditcard);
            PersistChangesToTrackedEntities();
            return context.Add(creditcard).Entity;



        }
        public CreditCard controllCreditCard(CreditCard creditcard)
        {


            CreditCard creditCard = context.Where(a => a.CardNumber == creditcard.CardNumber && a.Pin == creditcard.Pin).FirstOrDefault();

            return creditCard;
        
        }



        public void updateCreditCardBalance(CreditCard creditCardForUpdate)


        {
            

            if (db.Entry(creditCardForUpdate).State == EntityState.Detached)
            {

               
                context.Attach(creditCardForUpdate);
                
            }
            context.Update(creditCardForUpdate);
            SetModified(creditCardForUpdate);
           
            PersistChangesToTrackedEntities();

        }

        public CreditCard checkBalanceOfCreditCard(CreditCard card)


        {

            CreditCard creditCard = context.Where(a => a.CardId == card.CardId).FirstOrDefault();
       
            return creditCard;

        }
    }
    
}

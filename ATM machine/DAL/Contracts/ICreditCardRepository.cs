using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    
    
    public interface ICreditCardRepository : IRepository<CreditCard, Guid>
    {

        CreditCard addCreditCard(CreditCard creditCard);
        CreditCard controllCreditCard(CreditCard creditcard);

        void updateCreditCardBalance(CreditCard card);

        public CreditCard checkBalanceOfCreditCard(CreditCard card);
    }
    
}

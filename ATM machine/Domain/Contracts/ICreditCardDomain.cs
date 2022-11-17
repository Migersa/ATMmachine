using DTO.CreditCardDTO;
using DTO.DepositDTO;
using DTO.WithdrawDTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    
    public interface ICreditCardDomain
    {



        CreditCardDTO addCreditCard(CreditCardAdd creditcard);
        CreditCardDTO controllCreditCard(CreditCardCardNumberPin creditcard);

        IList<CreditCardDTO> getAllCreditCards();

        void changeBalanceUsingDeposit(DepositAdd deposit);

        CreditCard checkBalanceUsingDeposit(DepositAdd deposit);

        CreditCard checkBalanceUsingWithdraw(WithdrawAdd deposit);
        void changeBalanceUsingWithdraw(WithdrawAdd withdraw);

        CreditCardBalanceId getCreditCardBalance(CreditCardId id);
    }
    
}

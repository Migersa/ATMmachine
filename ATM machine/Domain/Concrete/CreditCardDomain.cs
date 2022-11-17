using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using DTO.CreditCardDTO;
using DTO.DepositDTO;
using DTO.WithdrawDTO;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    
    internal class CreditCardDomain : DomainBase, ICreditCardDomain
    {
        public CreditCardDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }

        private ICreditCardRepository creditcardRepository => _unitOfWork.GetRepository<ICreditCardRepository>();




        public IList<CreditCardDTO> getAllCreditCards()
        {
            IEnumerable<CreditCard> creditcards = creditcardRepository.GetAll();
            var test = _mapper.Map<IList<CreditCardDTO>>(creditcards);

            return test;
        }

        public CreditCardDTO addCreditCard(CreditCardAdd creditcard)


        {
            CreditCardDTO cardCredencials = new CreditCardDTO();


            cardCredencials.CardNumber= System.Text.Encoding.UTF8.GetBytes(creditcard.CardNumber);

            cardCredencials.Pin= System.Text.Encoding.UTF8.GetBytes(creditcard.Pin);
            cardCredencials.ExpirationDate = creditcard.ExpirationDate;
            cardCredencials.Balance = creditcard.Balance;

            var creditCardDto = _mapper.Map<CreditCardDTO, CreditCard>(cardCredencials);
            var cardAdded = creditcardRepository.addCreditCard(creditCardDto);
            return _mapper.Map<CreditCard, CreditCardDTO>(cardAdded);
        }
     public CreditCardDTO controllCreditCard(CreditCardCardNumberPin creditcard)
        {

         
            CreditCardDTO cardCredencials = new CreditCardDTO();


            cardCredencials.CardNumber = System.Text.Encoding.UTF8.GetBytes(creditcard.CardNumber) ;


               cardCredencials.Pin = System.Text.Encoding.UTF8.GetBytes(creditcard.Pin);
            var creditcardDTO = _mapper.Map<CreditCardDTO, CreditCard>(cardCredencials);


            var cardcontrolled = creditcardRepository.controllCreditCard(creditcardDTO);//check for null;
           

            var cardreturned = _mapper.Map<CreditCard, CreditCardDTO>(cardcontrolled);

            return cardreturned;
        }
       

        public void changeBalanceUsingDeposit(DepositAdd  deposit)


        {

            var balance = checkBalanceUsingDeposit(deposit);
            balance.Balance = deposit.DepositValue + balance.Balance;
          
            CreditCardDTO card = new CreditCardDTO();

            card.CardId = deposit.CardId;
            card.Balance = deposit.DepositValue + balance.Balance;


            var credit_card = _mapper.Map<CreditCardDTO, CreditCard>(card);
            creditcardRepository.updateCreditCardBalance(balance);

           

        }
     public   CreditCard checkBalanceUsingDeposit(DepositAdd deposit)
        {

            CreditCardId creditcard = new CreditCardId();
            creditcard.CardId = deposit.CardId;
            var card = _mapper.Map<CreditCardId, CreditCard>(creditcard);


            var balance = creditcardRepository.checkBalanceOfCreditCard(card);

            return balance;

        }
        public void changeBalanceUsingWithdraw(WithdrawAdd withdraw)


        {

            var balance = checkBalanceUsingWithdraw(withdraw);
            balance.Balance = balance.Balance - withdraw.WithdrawValue;
        
            CreditCardDTO card = new CreditCardDTO();
            card.CardId = withdraw.CardId;
            card.Balance = balance.Balance - withdraw.WithdrawValue;

          
            creditcardRepository.updateCreditCardBalance(balance);



        }
        public CreditCard checkBalanceUsingWithdraw(WithdrawAdd deposit)
        {

            CreditCardId c = new CreditCardId();
            c.CardId = deposit.CardId;
            var card = _mapper.Map<CreditCardId, CreditCard>(c);


            var balance = creditcardRepository.checkBalanceOfCreditCard(card);

            return balance;

        }
        public CreditCardBalanceId getCreditCardBalance(CreditCardId id)
        {

            var card = _mapper.Map<CreditCardId, CreditCard>(id);

            var balance = creditcardRepository.checkBalanceOfCreditCard(card);

            return _mapper.Map<CreditCard, CreditCardBalanceId>(balance);

        }

    }
    
}

using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
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
    
    internal class WithdrawDomain : DomainBase, IWithdrawDomain
    {
        public WithdrawDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }


        private IWithdrawRepository withdrawRepository => _unitOfWork.GetRepository<IWithdrawRepository>();



        private ICreditCardRepository creditcardRepository => _unitOfWork.GetRepository<ICreditCardRepository>();



        public IList<WithdrawDTO> getAllWithdraw()
        {
            IEnumerable<Withdraw> withdraws = withdrawRepository.GetAll();
            var test = _mapper.Map<IList<WithdrawDTO>>(withdraws);

            return test;
        }

        public WithdrawDTO addWithdraw(WithdrawAdd withdraw, CreditCard card)


        {

            WithdrawDTO  t1 = new WithdrawDTO();
           
            if(card.Balance >= withdraw.WithdrawValue)
            {

                var withdrawDto = _mapper.Map<WithdrawAdd, Withdraw>(withdraw);


                var withdrawAdded = withdrawRepository.addWithdraw(withdrawDto);
                return _mapper.Map<Withdraw, WithdrawDTO>(withdrawAdded);
            }

            else
            {

                return t1;
            }
           
            
        }





    }
    
}

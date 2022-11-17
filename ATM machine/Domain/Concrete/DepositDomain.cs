using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using DTO.CreditCardDTO;
using DTO.DepositDTO;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    
    internal class DepositDomain : DomainBase, IDepositDomain
    {
        public DepositDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }
        private IDepositRepository depositRepository => _unitOfWork.GetRepository<IDepositRepository>();



        private ICreditCardRepository creditcardRepository => _unitOfWork.GetRepository<ICreditCardRepository>();




        public IList<DepositDTO> getAllDeposit()
        {
            IEnumerable<Deposit> deposit = depositRepository.GetAll();
            
            var test = _mapper.Map<IList<DepositDTO>>(deposit);

           

            return test;
        }
        public DepositDTO addDeposit(DepositAdd deposit)


        {


            DepositDTO depositAdd = new DepositDTO();

            depositAdd.CardNumber= System.Text.Encoding.UTF8.GetBytes(deposit.CardNumber);

            depositAdd.CardId = deposit.CardId;
            depositAdd.DepositValue = deposit.DepositValue;


            var depositDto = _mapper.Map<DepositDTO, Deposit>(depositAdd);
            var depositAdded = depositRepository.addDeposit(depositDto);
           
            return _mapper.Map<Deposit, DepositDTO>(depositAdded);
        }


       

    }
    
}

using AutoMapper;
using DTO.CreditCardDTO;
using DTO.DepositDTO;

using DTO.WithdrawDTO;
using Entities.Models;
//using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappings
{
    public class GeneralProfile : Profile
    {
        
        
        #region 
        public GeneralProfile()
        {
            CreateMap<CreditCard, CreditCardDTO>().ReverseMap();
            CreateMap<CreditCardDTO, CreditCard>().ReverseMap();
           // CreateMap<CreditCard, CreditCardAdd>().ReverseMap();
            CreateMap<CreditCard, CreditCardCardNumberPin>().ReverseMap();

            CreateMap<CreditCard, CreditCardId>().ReverseMap();
            CreateMap< CreditCardCardNumberPin, CreditCard>().ReverseMap();
            CreateMap<CreditCardId, CreditCard>().ReverseMap();
            CreateMap<CreditCardBalanceId, CreditCard>().ReverseMap();
            CreateMap<Deposit, DepositAdd>().ReverseMap();
          //  CreateMap<DepositAdd, Deposit>().ReverseMap();

            CreateMap<Deposit, DepositDTO>().ReverseMap();
            CreateMap<Withdraw, WithdrawDTO>().ReverseMap();

            CreateMap<DepositDTO, Deposit>().ReverseMap();

            CreateMap<Withdraw, WithdrawAdd>().ReverseMap();
        }

        #endregion
        
        
    }
}

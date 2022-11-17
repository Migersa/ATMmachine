using DTO.WithdrawDTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    
    public interface IWithdrawDomain
    {

        WithdrawDTO addWithdraw(WithdrawAdd withdraw,CreditCard card );

        IList<WithdrawDTO> getAllWithdraw();


    }
    

}

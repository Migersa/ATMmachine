using DTO.DepositDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    
   public interface IDepositDomain
    {


        DepositDTO addDeposit(DepositAdd deposit);

        IList<DepositDTO> getAllDeposit();
    }
    
}

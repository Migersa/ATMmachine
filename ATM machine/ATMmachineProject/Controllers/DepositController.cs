using Microsoft.AspNetCore.Mvc;
using DTO.DepositDTO;
using Domain.Contracts;
using Entities.Models;

namespace HumanResourceProject.Controllers
{
    
    
    [ApiController]
    [Route("[controller]")]
    public class DepositController : Controller
    {

        private readonly IDepositDomain _depositDomain;
        private readonly ICreditCardDomain _creditCardDomain;

        private  DepositAdd deposit_In_Card =new DepositAdd();
  

        public DepositController(IDepositDomain depositDomain, ICreditCardDomain creditCardDomain)
        {
            _depositDomain = depositDomain;
            _creditCardDomain = creditCardDomain;
        }

        [HttpPost]
        [Route("AddDepositCard")]


        public IActionResult addDeposit( DepositAdd deposit)
        {

         




               
       
            DepositDTO deposit_Added_In_Card = _depositDomain.addDeposit(deposit);


            deposit_In_Card = deposit;


            if (deposit_In_Card == null)
            {
                return NotFound("No deposit is allow for this credit card");
                // return BadRequest(); 
            }

                return Ok(deposit_Added_In_Card);
            
        }
        
        [HttpPost]
        [Route("UpdateBalance")]

        public IActionResult update(DepositAdd deposit)
        {

          
                CreditCard card = _creditCardDomain.checkBalanceUsingDeposit(deposit);

                _creditCardDomain.changeBalanceUsingDeposit(deposit);

            if (card == null)
            {
                return NotFound("This credit card is no updated");
                //  return BadRequest();
            }

                return Ok();
            

        }


        [HttpGet]
        [Route("GetAllDeposit")]


        public IActionResult getAllDeposit()
        {

      
                var all_Deposits_In_Card = _depositDomain.getAllDeposit();

            if (all_Deposits_In_Card == null)
            {
                return NotFound("No  deposits for this credit card");
                // return BadRequest();
            }
                return Ok(all_Deposits_In_Card);
            
        }




    }
    
}

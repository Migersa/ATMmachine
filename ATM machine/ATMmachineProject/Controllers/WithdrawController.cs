using Domain.Contracts;
using DTO.WithdrawDTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceProject.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class WithdrawController : Controller
    {

        private readonly IWithdrawDomain _withdrawDomain;
        private readonly ICreditCardDomain _creditCardDomain;

        private WithdrawAdd deposit1 = new WithdrawAdd();
        private CreditCard c = new CreditCard();

        public WithdrawController(IWithdrawDomain withdrawDomain, ICreditCardDomain creditCardDomain)
        {
            _withdrawDomain = withdrawDomain;
            _creditCardDomain = creditCardDomain;
        }




        [HttpPost]
        [Route("TakeWithdrawCard")]


        public IActionResult addWithdraw(WithdrawAdd withdraw)
        {



            CreditCard card = _creditCardDomain.checkBalanceUsingWithdraw(withdraw);


            WithdrawDTO withdrawTaken = _withdrawDomain.addWithdraw(withdraw, card);
                deposit1 = withdraw;


            if (withdrawTaken == null)
            {
                return NotFound("This withdraw is not allowed for this credit card");

                //  return BadRequest();
            }


                return Ok(withdrawTaken);
            



        }


        [HttpPost]
        [Route("UpdateBalance1")]

        public IActionResult update1(WithdrawAdd d)
        {

          
                CreditCard card = _creditCardDomain.checkBalanceUsingWithdraw(d);

                _creditCardDomain.changeBalanceUsingWithdraw(d);
            if(card == null)
            {


                return NotFound("Balance isn't update");
                // return BadRequest();
            }
                return Ok();
            

        }


        [HttpGet]
        [Route("GetAllWithdraws")]


        public IActionResult getAllWithdrawsCards()
        {


                var allWithdraws = _withdrawDomain.getAllWithdraw();

            if (allWithdraws == null)
            {

                return NotFound("No withdraw for this credit card are in the system");
                // return BadRequest();
            }
                return Ok(allWithdraws);
            
        }


    }
    
}

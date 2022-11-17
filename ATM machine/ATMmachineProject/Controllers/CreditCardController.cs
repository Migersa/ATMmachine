using Domain.Contracts;
using DTO.CreditCardDTO;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceProject.Controllers
{
    
    

    [ApiController]
    [Route("[controller]")]
    public class CreditCardController : Controller
    {


        private readonly ICreditCardDomain _creditCardDomain;


        public CreditCardController(ICreditCardDomain creditcard1Domain)
        {
            _creditCardDomain = creditcard1Domain;
        }



        [HttpPost]
        [Route("AddCreditCard")]


        public IActionResult addCreditCard([FromRoute] CreditCardAdd creditcard)
        {

          


                CreditCardDTO credit_Card_Added = _creditCardDomain.addCreditCard(creditcard);
            if (credit_Card_Added == null)
            {
                return NotFound("This credit card is not exepted to add");
                //  return BadRequest();
            }
            

            return Ok(credit_Card_Added);
            
        }



        [HttpPost]
        [Route("ControllCreditCard")]


        public IActionResult controllCreditCard(CreditCardCardNumberPin creditcard)
        {

           

                CreditCardDTO credit_Card_Returned = _creditCardDomain.controllCreditCard(creditcard);
         
                return Ok(credit_Card_Returned);
            
        }


        [HttpGet]
        [Route("GetAllCreditCards")]


        public IActionResult getAllCreditCards()
        {

           

                var all_Credit_Cards = _creditCardDomain.getAllCreditCards();

            if (all_Credit_Cards == null)
            {

                return NotFound("No credit cards are in system");
                //  return BadRequest(); 
            }
                return Ok(all_Credit_Cards);
           
        }



        [HttpPost]
        [Route("GetCreditCardBalance")]


        public IActionResult getCreditCardBalance(CreditCardId id)
        {

           




                CreditCardBalanceId balance_Of_Card_Returned = _creditCardDomain.getCreditCardBalance(id);

            if (balance_Of_Card_Returned == null)
            {
                return NotFound("This credit card has no balance ");

                //return BadRequest(); 
            }
                return Ok(balance_Of_Card_Returned);
        
        }




    }
    
}

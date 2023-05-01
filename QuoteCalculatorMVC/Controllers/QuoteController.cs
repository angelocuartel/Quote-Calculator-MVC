using Microsoft.AspNetCore.Mvc;
using QuoteCalculatorMVC.Models;
using QuoteCalculatorMVC.Services;
using QuoteCalculatorMVC.Services.Implementations;
using QuoteCalculatorMVC.Utilities;

namespace QuoteCalculatorMVC.Controllers
{
    public class QuoteController : Controller
    {
        private readonly IQuoteService _quoteService;
        public QuoteController(IQuoteService quoteService, IConfiguration config)
        {
            _quoteService = quoteService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string hashedId)
        {
            var quoteInfo = await _quoteService.GetAsync<QuoteInformationModel>(hashedId);
            return View(quoteInfo);
        }

        [HttpGet]
        public IActionResult GetTotalPayment( decimal principal, short monthsToPay)
        {
            TotalPaymentModel payment = QuoteCalculatorUtil.GetTotalPayment(principal, monthsToPay);
            return Ok(payment);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] SavedQuotePaymentAndInformationModel model)
        {
            try
            {
                if (LoanValidatorUtil.IsLegalAge(model.QuoteInformation.DateOfBirth))
                {
                    await _quoteService.PostAsync(model);

                    return Ok();
                }

                return BadRequest("Cannot proceed, borrower is not in legal age");
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]

        public IActionResult Success()
        {
            return View();
        }
    }
}

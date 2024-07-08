using Calculator_With_SOLID_Principles.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Calculator_With_SOLID_Principles.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalculatorService _calculatorService;

        public HomeController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }
        public IActionResult Index()
        {  
            return View();
        }

        [HttpGet("Home/Calculate/{operation}/{x}/{y}")]
        public IActionResult Calculate(string operation, double x, double y)
        {
            try
            {
                var result = _calculatorService.PerformOperation(operation, x, y);
                return Ok(new { Result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }


    }
}

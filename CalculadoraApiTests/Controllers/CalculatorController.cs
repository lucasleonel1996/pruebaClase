using CalculadoraApiTests.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CalculadoraApiTests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ILogger<CalculatorController> logger, ICalculatorService calculatorService)
        {
            _logger = logger;
            _calculatorService = calculatorService;
        }

        [HttpGet("suma")]
        public async Task<IActionResult> Suma([FromQuery] double numA, [FromQuery] double numB)
        {
            _logger.LogInformation($"Request de SUMA recibida. {numA} + {numB}");
            return new OkObjectResult(new
            {
                Resultado = _calculatorService.Suma(numA, numB)
            });
        }

        [HttpGet("doblesuma")]
        public async Task<IActionResult> DobleSuma([FromQuery] double numA, [FromQuery] double numB)
        {
            _logger.LogInformation($"Request de DOBLE SUMA recibida. ({numA} + {numB}) * 2");
            return new OkObjectResult(new
            {
                Resultado = _calculatorService.DobleSuma(numA, numB)
            });
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(new
            {
                Status = "Todo bien capo"
            });
        }
    }
}

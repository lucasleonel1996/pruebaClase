using CalculadoraApiTests.Application;
using CalculadoraApiTests.Application.HistoryService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CalculadoraApiTests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoryController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly IHistoryService _historyService;

        public HistoryController(ILogger<CalculatorController> logger, IHistoryService historyService)
        {
            _logger = logger;
            _historyService = historyService;
        }

        [HttpGet]
        public IActionResult GetHistory()
        {
            _logger.LogInformation($"Request de GET HISTORY recibida");
            return new OkObjectResult(new
            {
                Resultado = _historyService.GetHistory()
            });
        }

        [HttpGet("sumOfAllResults")]
        public IActionResult DobleSuma()
        {
            _logger.LogInformation($"Request de GET SUM OF ALL RESULTS recibida");
            return new OkObjectResult(new
            {
                Resultado = _historyService.GetSumOfAllResults()
            });
        }

    }
}

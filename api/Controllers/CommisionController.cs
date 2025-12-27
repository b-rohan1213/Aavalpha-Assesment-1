using AvalphaTechnologies.CommissionCalculator.Business.Services.Interface;
using AvalphaTechnologies.CommissionCalculator.Data.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AvalphaTechnologies.CommissionCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommisionController : ControllerBase
    {
        private readonly ICommisionService commisionService;

        public CommisionController(ICommisionService commisionService)
        {
            this.commisionService = commisionService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CommissionCalculationResponse), StatusCodes.Status200OK)]
        public IActionResult Calculate(CommissionCalculationRequest calculationRequest)
        {
            return this.Ok(this.commisionService.getCommission(calculationRequest));
        }
    }
}

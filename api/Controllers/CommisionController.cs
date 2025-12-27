using AvalphaTechnologies.CommissionCalculator.Business.Services.Interface;
using AvalphaTechnologies.CommissionCalculator.Data.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AvalphaTechnologies.CommissionCalculator.Controllers
{
    /// <summary>
    /// Controller to hold commision related api endpoints.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CommisionController : ControllerBase
    {
        private readonly ICommisionService commisionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommisionController"/> class.
        /// </summary>
        /// <param name="commisionService">Commision service.</param>
        public CommisionController(ICommisionService commisionService)
        {
            this.commisionService = commisionService;
        }

        /// <summary>
        /// Api to calculate commision based on user input.
        /// </summary>
        /// <param name="calculationRequest">User input.</param>
        /// <returns>Commision calculation result.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(CommissionCalculationResponse), StatusCodes.Status200OK)]
        public IActionResult Calculate(CommissionCalculationRequest calculationRequest)
        {
            return this.Ok(this.commisionService.GetCommission(calculationRequest));
        }
    }
}

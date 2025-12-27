using AvalphaTechnologies.CommissionCalculator.Data.Dto;

namespace AvalphaTechnologies.CommissionCalculator.Business.Services.Interface
{
    /// <summary>
    /// Interface for commision service.
    /// </summary>
    public interface ICommisionService
    {
        /// <summary>
        /// Calculate commision.
        /// </summary>
        /// <param name="calculationRequest">User input.</param>
        /// <returns>Commision calculation result.</returns>
        CommissionCalculationResponse GetCommission(CommissionCalculationRequest calculationRequest);
    }
}

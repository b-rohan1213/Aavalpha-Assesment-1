using AvalphaTechnologies.CommissionCalculator.Data.Dto;

namespace AvalphaTechnologies.CommissionCalculator.Business.Services.Interface
{
    public interface ICommisionService
    {
        CommissionCalculationResponse getCommission(CommissionCalculationRequest calculationRequest);
    }
}

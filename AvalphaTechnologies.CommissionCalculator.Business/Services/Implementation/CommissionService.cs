using AvalphaTechnologies.CommissionCalculator.Business.Services.Interface;
using AvalphaTechnologies.CommissionCalculator.Data.Constatnts;
using AvalphaTechnologies.CommissionCalculator.Data.Dto;

namespace AvalphaTechnologies.CommissionCalculator.Business.Services.Implementation
{
    public class CommissionService : ICommisionService
    {
        public CommissionCalculationResponse getCommission(CommissionCalculationRequest calculationRequest)
        {
            if (calculationRequest == null)
            {
                throw new ArgumentNullException(nameof(calculationRequest), "Calculation request cannot be null.");
            }

            if (calculationRequest.LocalSalesCount < 0)
            {
                throw new InvalidDataException("Local sales count should be positive.");
            }

            if (calculationRequest.ForeignSalesCount < 0)
            {
                throw new InvalidDataException("Foreign sales count should be positive.");
            }

            if (calculationRequest.AverageSaleAmount < 0)
            {
                throw new InvalidDataException("Average sales amount should be positive.");
            }

            CommissionCalculationResponse commissionCalculationResponse = new CommissionCalculationResponse
            {
                AvalphaTechnologiesCommissionAmount = this.calculateTotalCommission(Commisions.AvalphaLocalSalesCommission,Commisions.AvalphaForeignSalesCommission, calculationRequest),
                CompetitorCommissionAmount = this.calculateTotalCommission(Commisions.CompetitorLocalSalesCommission,Commisions.CompetitorForeignSalesCommission, calculationRequest),
            };

            return commissionCalculationResponse;
        }

        private decimal calculateTotalCommission(decimal localSalesRate, decimal foreignSalesRate, CommissionCalculationRequest calculationRequest)
        {
            decimal localSalesCommission = (calculationRequest.LocalSalesCount * calculationRequest.AverageSaleAmount) * (localSalesRate / 100);
            decimal foreignSalesCommission = (calculationRequest.ForeignSalesCount * calculationRequest.AverageSaleAmount) * (foreignSalesRate / 100);
            return localSalesCommission + foreignSalesCommission;
        }
    }
}

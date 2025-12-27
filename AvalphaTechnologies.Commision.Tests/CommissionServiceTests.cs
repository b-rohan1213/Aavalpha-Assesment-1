using AvalphaTechnologies.CommissionCalculator.Business.Services.Implementation;
using AvalphaTechnologies.CommissionCalculator.Business.Services.Interface;
using AvalphaTechnologies.CommissionCalculator.Data.Dto;

namespace AvalphaTechnologies.Commision.Tests
{
    public class CommissionServiceTests
    {
        private ICommisionService commissionService;

        [Theory]
        [InlineData(10, 5, 100)]
        [InlineData(0, 5, 100)]
        [InlineData(5, 0, 100)]
        [InlineData(0, 0, 100)]
        [InlineData(10, 10, 0)]
        public void GetCommission_ValidInputs_ReturnsValidCommission(
           int localSales,
           int foreignSales,
           decimal averageSaleAmount)
        {
            // Arrange
            this.InitServices();

            var request = new CommissionCalculationRequest
            {
                LocalSalesCount = localSales,
                ForeignSalesCount = foreignSales,
                AverageSaleAmount = averageSaleAmount
            };

            // Act
            var result = this.commissionService.GetCommission(request);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.AvalphaTechnologiesCommissionAmount >= 0);
            Assert.True(result.CompetitorCommissionAmount >= 0);
        }

        [Theory]
        [InlineData(-1, 5, 100, "Local sales count should be positive")]
        [InlineData(5, -1, 100, "Foreign sales count should be positive")]
        [InlineData(5, 5, -100, "Average sales amount should be positive")]
        public void GetCommission_InvalidNumericInputs_ThrowsInvalidDataException(int localSales, int foreignSales, decimal averageSaleAmount, string expectedMessage)
        {
            // Arrange
            this.InitServices();
            var request = new CommissionCalculationRequest
            {
                LocalSalesCount = localSales,
                ForeignSalesCount = foreignSales,
                AverageSaleAmount = averageSaleAmount
            };

            // Act 
            var exception = Assert.Throws<InvalidDataException>(() => this.commissionService.GetCommission(request));

            // Assert
            Assert.Contains(expectedMessage, exception.Message);
        }

        [Fact]
        public void GetCommission_NullRequest_ThrowsArgumentNullException()
        {
            // Arrange
            this.InitServices();

            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => this.commissionService.GetCommission(null));

            // Assert
            Assert.Contains("Calculation request cannot be null", exception.Message);
        }

        private void InitServices()
        {
            this.commissionService = new CommissionService();
        }
    }
}
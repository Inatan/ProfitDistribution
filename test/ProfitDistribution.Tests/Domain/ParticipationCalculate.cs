using ProfitDistribution.Domain.Model;
using ProfitDistribution.Infrastructure;
using Xunit;

namespace ProfitDistribution.Tests.Domain
{
    public class ParticipationCalculate
    {
        [Theory]
        [InlineData(1.00, 1, 1,1,24.00)]
        [InlineData(1396.52, 2, 3, 1, 83791.20)]
        [InlineData(18053.25, 1, 3,5,173311.20)]
        [InlineData(5694.14, 3, 2,2, 170824.20)]
        void WhenCalculate_ReturnsExpectValue(decimal salary, int timeWeight, int areaWeight, int wageWeight,decimal expectedValue)
        {
            Participation participation = new Participation();
            decimal participationValue = participation.Calculate(salary, timeWeight, areaWeight, wageWeight);
            Assert.Equal<decimal>(participationValue, expectedValue);
        }

    }
}

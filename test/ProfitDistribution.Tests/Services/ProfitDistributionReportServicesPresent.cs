using Moq;
using ProfitDistribution.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProfitDistribution.Tests.Services
{
    public class ProfitDistributionReportServicesPresent
    {
        [Fact]
        public void WhenReceiveCurrency_ReturnsReport()
        {
            string value = "R$ 500.000,00";
            var mock = new Mock<IReportServices>();
            var services = mock.Object;

            //act
            var report = services.PresentReport(value);

            //assert
            Assert.NotNull(report);
        }
    }
}

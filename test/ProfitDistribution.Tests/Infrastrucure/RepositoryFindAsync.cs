using Moq;
using ProfitDistribution.Infrastructure;
using Xunit;

namespace ProfitDistribution.Tests.Infrastrucure
{
    public class RepositoryFindAsync
    {
        [Fact]
        public void WhenKeyExists_GetEntityObject()
        {
            string key = "0002949";
            var mock = new Mock<IRepository<object>>();
            var repo = mock.Object;

            //act
            repo.FindAsync(key);
            //assert
            mock.Verify(r => r.FindAsync(key), Times.Once());
        }
    }
}

using Moq;
using ProfitDistribution.Infrastructure;
using Xunit;

namespace ProfitDistribution.Tests.Infrastrucure
{
    public class RepositoryRemoveAsync
    {
        [Fact]
        public void WhenKeyExists_RemoveObject()
        {
            string key = "0002949";
            var mock = new Mock<IRepository<object>>();
            var repo = mock.Object;

            //act
            repo.RemoveAsync(key);
            //assert
            mock.Verify(r => r.RemoveAsync(key), Times.Once());
        }
    }
}

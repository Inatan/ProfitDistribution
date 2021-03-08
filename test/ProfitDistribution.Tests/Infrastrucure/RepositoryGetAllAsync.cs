using Moq;
using ProfitDistribution.Infrastructure;
using Xunit;

namespace ProfitDistribution.Tests.Infrastrucure
{
    public class RepositoryGetAllAsync
    {
        [Fact]
        public void WhenKeyExists_GetDictOFObjects()
        {
            var mock = new Mock<IRepository<object>>();
            var repo = mock.Object;

            //act
            repo.GetAllAsync();
            //assert
            mock.Verify(r => r.GetAllAsync(), Times.Once());
        }
    }
}

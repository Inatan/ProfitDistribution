using Moq;
using ProfitDistribution.Infrastructure;
using System.Threading.Tasks;
using Xunit;

namespace ProfitDistribution.Tests.Infrastrucure
{
    public class RepositoryGetAllAsync
    {
        [Fact]
        public async Task WhenKeyExists_GetDictOFObjects()
        {
            var mock = new Mock<IRepository<object>>();
            var repo = mock.Object;

            //act
            await repo.GetAllAsync();
            //assert
            mock.Verify(r => r.GetAllAsync(), Times.Once());
        }
    }
}

using Moq;
using ProfitDistribution.Infrastructure;
using System.Threading.Tasks;
using Xunit;

namespace ProfitDistribution.Tests.Infrastrucure
{
    public class RepositoryRemoveAsync
    {
        [Fact]
        public async Task WhenKeyExistsRemoveObject()
        {
            string key = "0002949";
            var mock = new Mock<IRepository<object>>();
            var repo = mock.Object;

            //act
            await repo.RemoveAsync(key);
            //assert
            mock.Verify(r => r.RemoveAsync(key), Times.Once());
        }
    }
}

using Moq;
using ProfitDistribution.Infrastructure;
using System.Threading.Tasks;
using Xunit;

namespace ProfitDistribution.Tests.Infrastrucure
{
    public class RepositoryFindAsync
    {
        [Fact]
        public async Task WhenKeyExistsGetEntityObject()
        {
            string key = "0002949";
            var mock = new Mock<IRepository<object>>();
            var repo = mock.Object;

            //act
            await repo.FindAsync(key);
            //assert
            mock.Verify(r => r.FindAsync(key), Times.Once());
        }
    }
}

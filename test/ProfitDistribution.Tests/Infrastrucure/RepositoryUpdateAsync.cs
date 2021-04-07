using Moq;
using ProfitDistribution.Infrastructure;
using System.Threading.Tasks;
using Xunit;

namespace ProfitDistribution.Tests.Infrastrucure
{
    public class RepositoryUpdateAsync
    {
        [Fact]
        public async Task WhenKeyExistsUpdateEntityObject()
        {
            object obj = new object();
            string key = "0002949";
            var mock = new Mock<IRepository<object>>();
            var repo = mock.Object;

            //act
            await repo.UpdateAsync(key, obj);

            //assert
            var ret = await repo.FindAsync(key);
            Assert.NotNull(ret);
        }
    }
}

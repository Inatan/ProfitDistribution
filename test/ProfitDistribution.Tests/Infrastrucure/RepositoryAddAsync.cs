using Moq;
using ProfitDistribution.Infrastructure;
using System.Threading.Tasks;
using Xunit;

namespace ProfitDistribution.Tests.Infrastrucure
{
    public class RepositoryAddAsync
    {
        [Fact]
        public async Task AddNewEntity_EntityObjectIsNotNull()
        {
            object obj = new object();
            string key = "000112";
            var mock = new Mock<IRepository<object>>();
            var repo = mock.Object;

            //act
            await repo.AddAsync(key, obj);

            //assert
            var ret = await repo.FindAsync(key);
            Assert.NotNull(ret);
        }
    }
}

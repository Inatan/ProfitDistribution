using Moq;
using ProfitDistribution.Infrastructure;
using Xunit;

namespace ProfitDistribution.Tests.Infrastrucure
{
    public class RepositoryUpdateAsync
    {
        [Fact]
        public void WhenKeyExists_UpdateEntityObject()
        {
            object obj = new object();
            string key = "0002949";
            var mock = new Mock<IRepository<object>>();
            var repo = mock.Object;

            //act
            repo.UpdateAsync(key, obj);

            //assert
            var ret = repo.FindAsync(key);
            Assert.NotNull(ret);
        }
    }
}

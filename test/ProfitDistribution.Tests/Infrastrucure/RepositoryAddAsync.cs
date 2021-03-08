using Moq;
using ProfitDistribution.Infrastructure;
using Xunit;

namespace ProfitDistribution.Tests.Infrastrucure
{
    public class RepositoryAddAsync
    {
        [Fact]
        public void AddNewEntity_EntityObjectIsNotNull()
        {
            object obj = new object();
            string key = "000112";
            var mock = new Mock<IRepository<object>>();
            var repo = mock.Object;

            //act
            repo.AddAsync(key, obj);

            //assert
            var ret = repo.FindAsync(key);
            Assert.NotNull(ret);
        }
    }
}

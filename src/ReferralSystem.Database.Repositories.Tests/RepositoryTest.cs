using System.Linq;
using System.Threading.Tasks;
using Moq;
using TestUtils;
using TestUtils.EntityFactories;
using Utils.Exceptions;
using Xunit;

namespace ReferralSystem.Database.Repositories.Tests
{
    public class RepositoryTest
    {
        [Fact]
        public async Task GetAllAsync_OkAsync()
        {
            var result = await new FakeRepository(nameof(FakeEntity), PrepareDatabase().Object).GetAllAsync();

            Assert.Single(result);
        }

        [Fact]
        public async Task GetByIdAsync_ExceptionAsync()
        {
            await Assert.ThrowsAsync<ResourceNotFoundException>(() => new FakeRepository(nameof(FakeEntity), PrepareDatabase().Object).GetByIdAsync(1));
        }

        [Fact]
        public async Task InsertAsync_OkAsync()
        {
            var connectionFactoryMock = PrepareDatabase();

            await new FakeRepository(nameof(FakeEntity), connectionFactoryMock.Object).InsertAsync(new FakeEntity());

            var result = await new FakeRepository(nameof(FakeEntity), connectionFactoryMock.Object).GetAllAsync();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task DeleteRowAsync_OkAsync()
        {
            var connectionFactoryMock = PrepareDatabase();

            await new FakeRepository(nameof(FakeEntity), connectionFactoryMock.Object).InsertAsync(new FakeEntity());

            var entities = await new FakeRepository(nameof(FakeEntity), connectionFactoryMock.Object).GetAllAsync();

            var entityToDelete = entities.FirstOrDefault();
            if (entityToDelete != null)
            {
                await new FakeRepository(nameof(FakeEntity), connectionFactoryMock.Object).DeleteAsync(entityToDelete.Id);
            }

            var result = await new FakeRepository(nameof(FakeEntity), connectionFactoryMock.Object).GetAllAsync();

            Assert.Single(result);
        }

        [Fact]
        public async Task UpdateAsync_OkAsync()
        {
            var connectionFactoryMock = PrepareDatabase();

            await new FakeRepository(nameof(FakeEntity), connectionFactoryMock.Object).InsertAsync(new FakeEntity());

            var entities = await new FakeRepository(nameof(FakeEntity), connectionFactoryMock.Object).GetAllAsync();

            var entityToUpdate = entities.FirstOrDefault();
            if (entityToUpdate != null)
            {
                entityToUpdate.FirstName = Faker.Name.First();
            }

            await new FakeRepository(nameof(FakeEntity), connectionFactoryMock.Object).UpdateAsync(entityToUpdate);

            var result = await new FakeRepository(nameof(FakeEntity), connectionFactoryMock.Object).GetAllAsync();

            Assert.Equal(entityToUpdate?.FirstName, result.FirstOrDefault()?.FirstName);
        }

        private static Mock<IDatabaseConnectionFactory> PrepareDatabase()
        {
            var connectionFactoryMock = new Mock<IDatabaseConnectionFactory>();
            var db = new InMemoryDatabase();
            var firstFakeEntity = new FakeEntity();
            db.Insert(firstFakeEntity);
            connectionFactoryMock.Setup(c => c.GetConnection()).Returns(db.OpenConnection());
            return connectionFactoryMock;
        }
    }
}
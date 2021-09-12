using System;
using Utils.Interfaces;

namespace TestUtils.EntityFactories
{
    public class FakeEntity : IBaseModel
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        public long AuthorId { get; set; }

        public long EditorId { get; set; }

        public string UpdateToken { get; set; }

        public FakeEntity()
        {
            Id = new Random((int)DateTimeOffset.Now.Ticks).Next(1, int.MaxValue);
            FirstName = Faker.Name.First();
            LastName = Faker.Name.Last();
            UpdateToken = Guid.NewGuid().ToString();
        }
    }
}
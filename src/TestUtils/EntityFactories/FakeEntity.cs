using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using ServiceStack;
using ServiceStack.DataAnnotations;
using Utils.Interfaces;

namespace TestUtils.EntityFactories
{
    public class FakeEntity : IBaseModel
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Default(typeof(DateTimeOffset), "20210101")]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

        [Default(typeof(DateTimeOffset), "20210101")]
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;

        public long AuthorId { get; set; }

        public long EditorId { get; set; }

        public FakeEntity()
        {
            Id = new Random((int)DateTimeOffset.Now.Ticks).Next(1, int.MaxValue);
            FirstName = Faker.Name.First();
            LastName = Faker.Name.Last();
        }
    }
}
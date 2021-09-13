namespace ReferralSystem.Models.Domain.Providers
{
    public class District
    {
        protected District()
        {
        }

        public string NameRu { get; protected set; }

        public string NameEn { get; protected set; }

        public string NameKk { get; protected set; }

        public double Polygon { get; protected set; }

        public string Color { get; protected set; }

        public long RegionId { get; protected set; }
    }
}
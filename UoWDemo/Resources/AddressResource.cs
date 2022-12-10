using UoWDemo.Entities;

namespace UoWDemo.Resources
{
    public class AddressResource
    {
        public int Id { get; init; }
        public string Country { get; init; }
        public string POBox { get; init; }
        public string City { get; init; }
        public string Street { get; init; }
        public string Apartment { get; init; }
        public Person Person { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
    }
}

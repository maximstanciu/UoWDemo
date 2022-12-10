using System.ComponentModel.DataAnnotations.Schema;
namespace UoWDemo.Entities
{
	public record Address : IEntity
    {
		public string Country { get; init; }
		public string POBox { get; init; }
		public string City { get; init; }
		public string Street { get; init; }
		public string Apartment { get; init; }

		[ForeignKey("PersonId")]
		public virtual Person Person { get; init; }
	}
}

namespace UoWDemo.Entities
{
    public record Person : IEntity
	{
		public string FirstName { get; init; }
		public string LastName { get; init; }

        public virtual ICollection<Address> Addresses { get; init; }
    }
}
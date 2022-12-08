namespace UoWDemo.Entities
{
    public record Person : IEntity
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
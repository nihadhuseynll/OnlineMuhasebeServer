namespace OnlineMuhasebeServer.Domain.Abstractions
{
	public abstract class Entity
	{
		public string Id { get; set; }
		public DateTime CretedDate { get; set; }
		public DateTime UpdateDate { get; set; }
	}
}

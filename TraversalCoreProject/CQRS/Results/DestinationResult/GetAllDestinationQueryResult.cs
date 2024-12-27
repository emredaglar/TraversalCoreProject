namespace TraversalCoreProject.CQRS.Results.DestinationResult
{
	//get gibi işlemleri yapacak p tutan
	public class GetAllDestinationQueryResult
	{
		public int id { get; set; }
		public string city { get; set; }
		public string dayNight { get; set; }
		public double price { get; set; }
		public int capacity { get; set; }

	}
}

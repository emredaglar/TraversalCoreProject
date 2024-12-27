namespace TraversalCoreProject.CQRS.Commands.DestinationCommands
{
    public class CreateDestinationCommand
    {//post gibi işlemleri yapacak p tutan
        public string City { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }
    }
}

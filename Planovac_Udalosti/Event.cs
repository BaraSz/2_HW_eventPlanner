namespace Planovac_Udalosti
{
    public class Event
    {
        public string NameOfEvent { get; set; }
        public DateTime DateOfEvent { get; set; }

        public Event(string nameOfEvent, DateTime dateOfEvent)
        {
            NameOfEvent = nameOfEvent;
            DateOfEvent = dateOfEvent;
        }
        public void WriteListOfEvents()
        {
            DateOfEvent = DateOfEvent.Date;
            DateTime acctualDate = DateTime.Now.Date;
            int daysLeft = Math.Abs((DateOfEvent - acctualDate).Days);

            if (DateOfEvent > acctualDate)
            {
                Console.WriteLine($"EVENT: {NameOfEvent}, with date {DateOfEvent:yyyy-MM-dd} will happend in {daysLeft} days");
            }
            else if (DateOfEvent < acctualDate)
            {
                Console.WriteLine($"EVENT: {NameOfEvent}, with date {DateOfEvent:yyyy-MM-dd} happend {daysLeft} days ago");
            }
            else
            {
                Console.WriteLine($"EVENT: {NameOfEvent}, with date {DateOfEvent:yyyy-MM-dd}  is today");
            }
        }
    }
}

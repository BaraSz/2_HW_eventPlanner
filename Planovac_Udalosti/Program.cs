namespace Planovac_Udalosti;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello!");
        List<Event> events = new List<Event>();
        Dictionary<DateTime, int> dict = new Dictionary<DateTime, int>();

        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("[1]EVENT");
            Console.WriteLine("[2]LIST");
            Console.WriteLine("[3]STATS");
            Console.WriteLine("[4]END");

            string userChoice = Console.ReadLine();

            if (userChoice == "1") // nitpick: pomocna metoda
            {
                Console.WriteLine("Enter a new event name and date in the format: [event name];[YYYY-MM-DD].");
                string newEvent = Console.ReadLine();
                string[] newEventSplit = newEvent.Split(";", StringSplitOptions.RemoveEmptyEntries);

                while (true)
                {
                    if (newEventSplit.Length == 2)
                    {
                        string nameOfEvent = newEventSplit[0];
                        string dateOfEvent = newEventSplit[1];

                        try
                        {
                            DateTime parsedDate = DateTime.ParseExact(dateOfEvent, "yyyy-MM-dd", null);
                            Event userEvent = new Event(nameOfEvent, parsedDate);
                            AddEvent(userEvent, dict, events);
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid enter. Please write date in the format: YYYY-MM-DD");
                            newEvent = Console.ReadLine();
                            newEventSplit = newEvent.Split(";", StringSplitOptions.RemoveEmptyEntries);
                        }
                    }

                    else
                    {
                        Console.WriteLine("Invalid enter");
                        Console.WriteLine("Enter a new event name and date in the format: [event name];[YYYY-MM-DD].");
                        newEvent = Console.ReadLine();
                        newEventSplit = newEvent.Split(";", StringSplitOptions.RemoveEmptyEntries);
                    }
                }
            }

            else if (userChoice == "2")
            {
                foreach (Event eventItem in events)
                {
                    eventItem.WriteListOfEvents();
                }
            }

            else if (userChoice == "3")
            {
                foreach (var eventPair in dict)
                {
                    if (eventPair.Value > 1)
                    {
                        Console.WriteLine($"{eventPair.Key:yyyy-MM-dd}: {eventPair.Value} events");
                    }
                    else
                    {
                        Console.WriteLine($"{eventPair.Key:yyyy-MM-dd}: {eventPair.Value} event");
                    }
                }
            }

            else if (userChoice == "4")
            {
                Console.WriteLine("The program is closing.");
                return;
            }
            else
            {
                Console.WriteLine("Invalid option, choose again.");
            }
        }
    }

    static void AddEvent(Event eventItem, Dictionary<DateTime, int> dict, List<Event> events)
    {
        events.Add(eventItem);

        if (dict.ContainsKey(eventItem.DateOfEvent))
        {
            dict[eventItem.DateOfEvent]++;
        }
        else
        {
            dict[eventItem.DateOfEvent] = 1;
        }
    }
}





using System.Formats.Asn1;
using System.Runtime.CompilerServices;

namespace Planovac_Udalosti;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello!");
        List<Event> events = new List<Event>();

        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("[1]EVENT");
            Console.WriteLine("[2]LIST");
            Console.WriteLine("[3]STATS");
            Console.WriteLine("[4]END");

            string userChoice = Console.ReadLine();

            if (userChoice == "1")
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
                            string[] dateOfEventSplit = dateOfEvent.Split("-", StringSplitOptions.RemoveEmptyEntries);

                            int yearOfEvent = int.Parse(dateOfEventSplit[0]);
                            int monthOfEvent = int.Parse(dateOfEventSplit[1]);
                            int dayOfEvent = int.Parse(dateOfEventSplit[2]);

                            DateTime parsedDate = new DateTime(yearOfEvent, monthOfEvent, dayOfEvent);
                            Event userEvent = new Event(nameOfEvent, parsedDate);
                            events.Add(userEvent);
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
                Dictionary<DateTime, int> dict = new Dictionary<DateTime, int> { };

                foreach (Event eventItem in events)
                {
                    if (dict.ContainsKey(eventItem.DateOfEvent))
                    {
                        dict[eventItem.DateOfEvent]++;
                    }
                    else
                    {
                        dict[eventItem.DateOfEvent] = 1;
                    }

                }

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
            /*--------nejsem si jista jak jinak to napsat aby se mi pri opakovanem spatnem vstupu nezobrazovalo Choose an option 1-4 a hned za tim aby mi nevyjela zakladni "nabidka"----*/
            else
            {
                /* Console.WriteLine("Choose an option 1-4");
                userChoice = Console.ReadLine(); */
                continue;
            }
        }
    }
}





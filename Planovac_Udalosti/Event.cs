using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

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
            int dayLeft;

            if (DateOfEvent > acctualDate)
            {
                dayLeft = (DateOfEvent - acctualDate).Days;
                Console.WriteLine($"EVENT: {NameOfEvent}, with date {DateOfEvent:yyyy-MM-dd} will happend in {dayLeft} days");
            }

            else if (DateOfEvent < acctualDate)
            {
                dayLeft = (acctualDate - DateOfEvent).Days;
                Console.WriteLine($"EVENT: {NameOfEvent}, with date {DateOfEvent:yyyy-MM-dd} happend {dayLeft} days ago");
            }

            else
            {
                Console.WriteLine($"EVENT: {NameOfEvent}, with date {DateOfEvent:yyyy-MM-dd}  is today");
            }

        }
    }
}

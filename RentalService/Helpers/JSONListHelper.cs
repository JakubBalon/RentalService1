using RentalService.Models;
using System.Linq;

namespace RentalService.Helpers
{
    public static class JSONListHelper
    {
        //Serialization models
        public static string GetEventListJSONString(List<Rental> events)
        {
            var rentalList = new List<Event>();
            

            foreach(var rental in events)
            {
                var myrental = new Event()
                {
                    id = rental.RentalId,
                    start = rental.RentalStartTime,
                    end = rental.RentalEndTime,
                    extendedProps = rental.RentedEquipment.Id,
                    title = rental.RentedEquipmentName
                   
                };
                rentalList.Add(myrental);
            }
            return System.Text.Json.JsonSerializer.Serialize(rentalList);
        }

        public static string GetResourcesListJSONString(List<Equipment> resources)
        {
            var resourceList = new List<Resource>();

            foreach(var equipment in resources)
            {
                var resource = new Resource()
                {
                    id = equipment.Id,
                    title = equipment.EquipmentName
                };
                resourceList.Add(resource);
            }
                return System.Text.Json.JsonSerializer.Serialize(resourceList);
        }
    }

    public class Event //FullCalendar class
    {
        public int id { get; set; }
        public DateTime start { get; set; }

        public DateTime end { get; set; }

        public int extendedProps { get; set; }

        public string title { get; set; }

       

    }

    public class Resource
    {
        public int id { get; set; }
        public string title { get; set; }


    }

}

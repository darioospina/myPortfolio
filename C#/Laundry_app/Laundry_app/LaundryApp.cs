using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Laundry_app
{
    public class LaundryApp
    {
        public List<ServiceProvider> ListOfServiceProviders = new List<ServiceProvider>();
        public List<Customer> ListOfCustomers = new List<Customer>();
        public double PickupLatitude { get; set; }
        public double PickupLongitude { get; set; }
        public double DropoffLatitude { get; set; }
        public double DropoffLongitude { get; set; }

        private static readonly double FeePerKm = 0.5; // Static fee for calculating the cost of service
        public void AddServiceProvider(ServiceProvider spObj) {
            ListOfServiceProviders.Add(spObj);
        }

        // This method updates the location of the Service Provider
        public void UpdateLocation<T>(int ID, double latitude, double longitude, List<ServiceProvider> myList)
        {
            for(int member = 0; member <= myList.Count -1; member++)
            {
                if(myList[member].ID == ID)
                {
                    myList[member].Latitude = latitude;
                    myList[member].Longitude = longitude;
                }
            }
        }

        // This method calculates the distance in Kilometers between two coordinates using the Haversine Formula
        public double CalculateDistance(double lat1, double lat2, double long1, double long2) 
        {
            double R = 6378; // Equatorial radius
            var lat = (Math.PI / 180) * (lat2 - lat1);
            var lng = (Math.PI / 180) * (long2 - long1);
            var h1 = Math.Sin(lat / 2) * Math.Sin(lat / 2) + Math.Cos((Math.PI / 180) * lat1) * Math.Cos((Math.PI / 180) * lat2) * Math.Sin(lng / 2) * Math.Sin(lng / 2);
            var h2 = 2 * Math.Asin(Math.Min(1, Math.Sqrt(h1)));
            return R * h2;
        }
        
        // This method calculates how many hours left from the time of the Service Request to the end of the shift of the Service Provider
        public int CalculateHoursForShiftEnd(int Shift_end)
        {
            int CurrentTime = DateTime.Now.Hour;
            int HoursLeft;
            if (Shift_end - CurrentTime <= 0)
            {
                HoursLeft = 0;
            } else
            {
                HoursLeft = Shift_end - CurrentTime;
            }
            return HoursLeft;
        }

        public void AddACustomer(string Name, int Id)
        {
            Customer newCustomer = new Customer(Name, Id);
            ListOfCustomers.Add(newCustomer);
        }

        // This methid calculates the cost of the service based on the distance from the Service Provider location to the pickup location and from the pickup location to the dropoff location
        public void CostOfService(double distance1, double distance2)
        {
            double Cost1 = (distance1 * FeePerKm);
            double Cost2 = (distance2 * FeePerKm);
            double TotalCost = Cost1 + Cost2;
            Console.WriteLine("The cost of the service is CAD$ {0} including CAD$ {1} for pickup and CAD$ {2} for dropoff.", Math.Round(TotalCost, 1), Math.Round(Cost1, 1), Math.Round(Cost2, 1));
        }

        // This method retrieves the information from the Service Provider that best suits the criteria entered in the method RequestService. 
        public void BestMatch(IEnumerable<ServiceProvider> myList, double PickupLatitude, double PickupLongitude, double DropoffLatitude, double DropoffLongitude)
        {
            string Name = myList.First().Name;
            Console.WriteLine("-----------------------------");
            Console.WriteLine("You have matched a driver. {0} is aproaching to your location.", Name);
            CostOfService(myList.First().Distance, CalculateDistance(PickupLatitude, DropoffLatitude, PickupLongitude, DropoffLongitude));
            Console.WriteLine(myList.First().PrintInfo());
            Console.WriteLine("-----------------------------");
        }

        // This is the method to be used by the Customer to request a service.
        public void RequestService(int CustomerID, int Weight, double PickupLatitude, double PickupLongitude, double DropoffLatitude, double DropoffLongitude)
        {
            bool CustomerExist = false;
            for (int i = 0; i <= ListOfCustomers.Count-1; i++)
            {
                if (ListOfCustomers[i].ID == CustomerID)
                {
                    Request();
                    CustomerExist = true;
                }
            }
            if(CustomerExist == false)
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("The customer with ID {0} was not found in our System. Please try with different paramenters.", CustomerID);
                Console.WriteLine("-----------------------------");
            }

            void Request()
            {
                foreach (var provider in ListOfServiceProviders)
                {
                    provider.Distance = CalculateDistance(PickupLatitude, provider.Latitude, PickupLongitude, provider.Longitude);
                    provider.TimeLeft = CalculateHoursForShiftEnd(provider.ShiftEnd);
                }
                // Using the LINQ library to sort the list by Type of Vehicle, Distance and Time for the end of the shift.
                IEnumerable<ServiceProvider> sortedList = ListOfServiceProviders.Where(sp => sp.GetCapacity() >= Weight).OrderBy(sp => sp.Distance).ThenByDescending(sp => sp.TimeLeft);
                BestMatch(sortedList, PickupLatitude, PickupLongitude, DropoffLatitude, DropoffLongitude);
            }
        }
    }
}

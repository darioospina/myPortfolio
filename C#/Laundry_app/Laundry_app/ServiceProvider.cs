using System;
using System.Collections.Generic;
using System.Text;

namespace Laundry_app
{
    public abstract class ServiceProvider
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Distance { get; set; }
        public int ShiftEnd { get; set; }
        public double TimeLeft { get; set; }

        public ServiceProvider(string name, int iD, int shiftEnd, double latitude, double longitude)
        {
            this.Name = name;
            this.ID = iD;
            this.ShiftEnd = shiftEnd;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        // Copy Constructor
        public ServiceProvider(ServiceProvider spObj)
        {
            Name = spObj.Name;
            ID = spObj.ID;
            ShiftEnd = spObj.ShiftEnd;
            Longitude = spObj.Longitude;
            Latitude = spObj.Latitude;
            Distance = spObj.Distance;
            TimeLeft = spObj.TimeLeft;
        }

        public abstract int GetCapacity();

        public string PrintInfo()
        {
            string myMessage = $"Your Service Provider's name is {Name}, he/she is {Math.Round(Distance, 1)}Kms away from your pickup location.";
            return myMessage;
        }
    }
}

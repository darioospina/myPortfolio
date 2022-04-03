using System;
using System.Collections.Generic;
using System.Text;

namespace Laundry_app
{
    public class CarDriver: ServiceProvider
    {
        public CarDriver(string name, int iD, int shiftEnd, double latitude, double longitude) : base(name, iD, shiftEnd, latitude, longitude) { }
        public CarDriver(CarDriver carObj) : base(carObj) { }
        public override int GetCapacity() { return 5; }
    }
}

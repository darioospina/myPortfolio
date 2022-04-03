using System;
using System.Collections.Generic;
using System.Text;

namespace Laundry_app
{
    public class TruckDriver: ServiceProvider
    {
        public TruckDriver(string name, int iD, int shiftEnd, double latitude, double longitude) : base(name, iD, shiftEnd, latitude, longitude) { }
        public TruckDriver(TruckDriver truckObj) : base(truckObj) { }
        public override int GetCapacity() { return 25; }
    }
}

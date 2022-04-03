using System;
using System.Collections.Generic;
using System.Text;

namespace Laundry_app
{
    public class Customer
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public Customer(string name, int iD)
        {
            this.Name = name;
            this.ID = iD;
        }

    }
}


using System;
using System.Collections.Generic;
using System.Text;

namespace ContactPersonen3.Data
{
    public class Address
    {
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public override string ToString()
        {
            string address = "";
            address += Street + " " + HouseNumber +", " + PostalCode + " "+ City;
            return address;
        }
    }
}

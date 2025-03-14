using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2OOP2
{
    public class Airport
    {

        //private data
        private string? airportCode;
        private string? airportName;

        //public data
        public string? AirportCode { get { return airportCode; } set { airportCode = value; } }
        public string? AirportName { get { return airportName; } set { airportName = value; } }

        public Airport(string airportCode, string airportName)
        {
            this.airportCode = airportCode;
            this.airportName = airportName;
        }
    }
}

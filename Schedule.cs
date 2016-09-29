using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHBPbus
{
    public static class Schedule
    {
        public const string arrivalsFileName = "Arrivals.json";
        public const string departuresFileName = "Departures.json";

        static List<Shuttle> arrivals = new List<Shuttle>();

        public static List<Shuttle> Arrivals
        {
            get
            {
                return arrivals;
            }

            set
            {
                arrivals = value;
            }
        }

        static List<Shuttle> departures = new List<Shuttle>();
        public static List<Shuttle> Departures
        {
            get
            {
                return departures;
            }

            set
            {
                departures = value;
            }
        }
    }
}

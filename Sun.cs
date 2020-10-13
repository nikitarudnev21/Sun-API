using System;
using System.Collections.Generic;
using System.Text;

namespace SunAPI
{
    public class Sun
    {
        public Results Results { get; set; }
        public string Status { get; set; }
    }
    public class Results
    {
        public string Sunrise { get; set; }
        public string SunSet { get; set; }
        public string Solar_Noon { get; set; }
        public string Day_Length { get; set; }
        public string Civil_Twilight_Begin { get; set; }
        public string Civil_Twilight_End { get; set; }
        public string Nautical_Twilight_Begin { get; set; }
        public string Nautical_Twilight_End { get; set; }
        public string Astronomical_Twilight_Begin { get; set; }
        public string Astronomical_Twilight_End { get; set; }
    }
}

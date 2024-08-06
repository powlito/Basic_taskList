using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaulHagerling_Example
{
    public static class Helper
    {
        public static DayOfWeek dayFromString(string dayString)
        {
            switch (dayString.ToLower())
            {
                case "sunday":
                    return DayOfWeek.Sunday;
                case "monday":
                    return DayOfWeek.Monday;
                case "tuesday":
                    return DayOfWeek.Tuesday;
                case "wednesday":
                    return DayOfWeek.Wednesday;
                case "thursday":
                    return DayOfWeek.Thursday;
                case "friday":
                    return DayOfWeek.Friday;
                case "saturday":
                    return DayOfWeek.Saturday;
                default:
                    return DayOfWeek.Sunday;
            }
        }  

    }
}

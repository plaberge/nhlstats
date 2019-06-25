using System;
using System.Collections.Generic;
using System.Text;

namespace NHLStats
{
    public static class Utilities
    {
        public static string GetSeasonFromDate(string inDate)
        {
            string inYear = inDate.Substring(0, 4);
            string inMonth = inDate.Substring(5, 2);
            string inDay = inDate.Substring(8, 2);

            if ((Convert.ToInt32(inMonth) > 6))
            {
                return inYear + (Convert.ToInt32(inYear) + 1).ToString();
            }
            else
            {
                return (Convert.ToInt32(inYear) - 1).ToString() + inYear;
            }
            
        }


    }
}

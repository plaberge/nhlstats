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

        public static string GetTodaysDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }   

        public static string GetYesterdaysDate()
        {
            return DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
        }   

        public static int ConvertPeriodTimeToSeconds(string periodTime)
        {
            string[] minutesSeconds = periodTime.Split(':');

            int minutes = 0;
            int seconds = 0;
            bool isANumber = false;

            // Try to parse the string into an int, otherwise default the value to 0.
            if (int.TryParse(minutesSeconds[0], out minutes) == false)
            {
                minutes = 0;
            }

            // Try to parse the string into an int, otherwise default the value to 0.
            if (int.TryParse(minutesSeconds[1], out seconds) == false)
            {
                seconds = 0;
            }

            //minutes = Convert.ToInt32(minutesSeconds[0]);  // "0M:48"; 
            //seconds = Convert.ToInt32(minutesSeconds[1]); // "10:0J"


            return (minutes * 60) + seconds;
        }

        public static string ConvertSecondsToPeriodTime(int inSeconds)
        {
            int minutes = 0;
            int seconds = 0;
            string periodTime = "";

            minutes = inSeconds / 60;
            seconds = inSeconds % 60;
            periodTime = minutes.ToString() + ":" + seconds.ToString();

            return periodTime;

        }


    }
}

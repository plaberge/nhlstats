using System;
using System.Collections.Generic;
using System.Globalization;
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

        public static int GetOrdinalDayOfWeek(string dateString)
        {
            DateTime date = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            // Getting the ordinal day of the week (0 for Sunday, 1 for Monday, ..., 6 for Saturday)
            int ordinalDayOfWeek = ((int)date.DayOfWeek == 0) ? 7 : (int)date.DayOfWeek;
            ordinalDayOfWeek--;


            return ordinalDayOfWeek;
        }

        public static string[] getRatioFromString(string ratio)
        {
            string[] ratioArray = ratio.Split('/');
            return ratioArray;
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

        public static int GetCurrentAge(string birthDate)
        {

            DateTime dob = DateTime.ParseExact(birthDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime today = DateTime.Today;
            int age = today.Year - dob.Year;
            if (dob > today.AddYears(-age)) age--;

            return age;
        }

        public static string SafeOutput (string dataInput, string desiredOutputType)
        {
            if (dataInput == null || dataInput.ToString() == "" || dataInput.ToString() == " ")
            {
                if (desiredOutputType == "string")
                    return "NULL";
                else if (desiredOutputType == "time")
                    return "00:00";
                else if (desiredOutputType == "number")
                    return "0";
                else
                    return "0";
            }
            else
                return dataInput;
        }


    }
}

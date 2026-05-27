using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    internal class DateTime
    {
        private long timeToken;// seconds since 2000-01-01T00:00:00

        public long TimeToken { get { return timeToken; } set { timeToken = value; } }

        //Constructor

        public DateTime(long t)
        {
            this.timeToken = t;
        }

        //Methods

        public override string ToString() //YYYY-MM-DDThh:mm:ss
        {
            List<string> dateList = GetDateTimeList();
            string result = "";
            for (int i = 0; i < dateList.Count; i++)
            {
                result += dateList[i];
                if (i < 2) { result += "-"; }
                else if (i == 2) { result += "T"; }
                else if (i == 3 || i == 4) { result += ":"; }
            }
            return result;
        }

        private List<string> GetDateTimeList() //returns string[6] with [0] == YYYY, [1] == MM, [2] == DD, [3] == hh, [4] == mm, [5] == ss
        {
            //seconds in a day: 86400
            //seconds in a month
            //28 days: 2419200
            //29 days: 2505600
            //30 days: 2592000
            //31 days: 2678400
            //seconds in a regular year: 31536000
            //seconds in a leap year: 31622400

            List<string> dateTimeList = new List<string>();
            long years, leapDays, token = TimeToken;
            int leapSeconds, monthSeconds;
            byte days, hours, minutes, seconds;

            //years:
            leapDays = token / (31536000 * 4 + 86400); //number of leapdays in token
            token -= leapDays * 86400; //substract leapdays from token
            years = token / 31536000; //number of years can now be calculated easily
            dateTimeList.Add(years.ToString());
            token -= years * 31536000; //substract years from token, now contains only months, days, etc

            //months:
            //check for leap year
            if (years % 4 == 0 && (years % 100 != 0 || years % 400 == 0))
            {
                leapSeconds = 86400; //add a leap day
            }
            else
            {
                leapSeconds = 0;
            }
            //go through cases, since months are irregular
            if (token > 28857600 + leapSeconds) //December
            {
                dateTimeList.Add("12");
                monthSeconds = 28857600;
            }
            else if (token > 26265600 + leapSeconds) //November
            {
                dateTimeList.Add("11");
                monthSeconds = 26265600;
            }
            else if (token > 23587200 + leapSeconds) //October
            {
                dateTimeList.Add("10");
                monthSeconds = 23587200;
            }
            else if (token > 20995200 + leapSeconds) //September
            {
                dateTimeList.Add("09");
                monthSeconds = 20995200;
            }
            else if (token > 18316800 + leapSeconds) //August
            {
                dateTimeList.Add("08");
                monthSeconds = 18316800;
            }
            else if (token > 15638400 + leapSeconds) //Juli
            {
                dateTimeList.Add("07");
                monthSeconds = 15638400;
            }
            else if (token > 13046400 + leapSeconds) //June
            {
                dateTimeList.Add("06");
                monthSeconds = 13046400;
            }
            else if (token > 10368000 + leapSeconds) //May
            {
                dateTimeList.Add("05");
                monthSeconds = 10368000;
            }
            else if (token > 7776000 + leapSeconds) //April
            {
                dateTimeList.Add("04");
                monthSeconds = 7776000;
            }
            else if (token > 5097600 + leapSeconds) //March
            {
                dateTimeList.Add("03");
                monthSeconds = 5097600;
            }
            else if (token > 2678400) //February
            {
                dateTimeList.Add("02");
                monthSeconds = 2678400;
            }
            else //January
            {
                dateTimeList.Add("01");
                monthSeconds = 0;
            }

            token -= monthSeconds;

            //remaining time units are regular:
            //days:
            days = (byte)(token / 86400);
            token -= days * 86400;
            if (days > 9) { dateTimeList.Add(days.ToString()); }
            else { dateTimeList.Add("0" + days.ToString()); }

            //hours:
            hours = (byte)(token / 3600);
            token -= hours * 3600;
            if (hours > 9) { dateTimeList.Add(hours.ToString()); }
            else { dateTimeList.Add("0" + hours.ToString()); }

            //minutes:
            minutes = (byte)(token / 60);
            token -= minutes * 60;
            if (minutes > 9) {dateTimeList.Add(minutes.ToString()); }
            else { dateTimeList.Add("0" + minutes.ToString()); }

            //seconds:
            seconds = (byte)token;
            if (seconds > 9) { dateTimeList.Add(seconds.ToString()); }
            else { dateTimeList.Add("0" + seconds.ToString()); }

            return dateTimeList;
        }
    }
}

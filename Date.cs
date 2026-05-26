using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalender
{
    internal class Date
    {
        private long timeToken;// seconds since 2000-01-01T00:00

        public long TimeToken { get { return timeToken; } set { timeToken = value; } }

        //Constructor

        public Date(long t)
        {
            this.timeToken = t;
        }

        //Methods

        public override string ToString() //YMD
        {
            string[] dateArray = GetDateArray();
            return dateArray[0] + "-" + dateArray[1] + "-" + dateArray[2];
        }

        private string[] GetDateArray() //returns string[6] with [0] == YYYY, [1] == MM, [2] == DD, [3] == hh, [4] == mm, [5] == ss
        {
            //seconds in a day: 86400
            //seconds in a month
                //28 days: 2419200
                //29 days: 2505600
                //30 days: 2592000
                //31 days: 2678400
            //seconds in a regular year: 31536000
            //seconds in a leap year: 31622400

            string[] dateArray = new string[6];
            long years, leapDays, token = TimeToken;
            int leapSeconds, monthSeconds;
            byte days, hours, minutes, seconds;

            //years:
            leapDays = token / (31536000 * 4 + 86400); //number of leapdays in token
            token -= leapDays * 86400; //substract leapdays from token
            years = token / 31536000; //number of years can now be calculated easily
            dateArray[0] = years.ToString();
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
                dateArray[1] = "12";
                monthSeconds = 28857600;
            }
            else if (token > 26265600 + leapSeconds) //November
            {
                dateArray[1] = "11";
                monthSeconds = 26265600;
            }
            else if (token > 23587200 + leapSeconds) //October
            {
                dateArray[1] = "10";
                monthSeconds = 23587200;
            }
            else if (token > 20995200 + leapSeconds) //September
            {
                dateArray[1] = "09";
                monthSeconds = 20995200;
            }
            else if (token > 18316800 + leapSeconds) //August
            {
                dateArray[1] = "08";
                monthSeconds = 18316800;
            }
            else if (token > 15638400 + leapSeconds) //Juli
            {
                dateArray[1] = "07";
                monthSeconds = 15638400;
            }
            else if (token > 13046400 + leapSeconds) //June
            {
                dateArray[1] = "06";
                monthSeconds = 13046400;
            }
            else if (token > 10368000 + leapSeconds) //May
            {
                dateArray[1] = "05";
                monthSeconds = 10368000;
            }
            else if (token > 7776000 + leapSeconds) //April
            {
                dateArray[1] = "04";
                monthSeconds = 7776000;
            }
            else if (token > 5097600 + leapSeconds) //March
            {
                dateArray[1] = "03";
                monthSeconds = 5097600;
            }
            else if (token > 2678400) //February
            {
                dateArray[1] = "02";
                monthSeconds = 2678400;
            }
            else //January
            {
                dateArray[1] = "01";
                monthSeconds = 0;
            }

            token -= monthSeconds;

            //remaining time units are regular:
            //days:
            days = (byte)(token / 86400);
            token -= days * 86400;
            if (days > 9) { dateArray[2] = days.ToString(); }
            else { dateArray[2] = "0" + days.ToString(); }

            //hours:
            hours = (byte)(token / 3600);
            token -= hours * 3600;
            if (hours > 9) { dateArray[3] = hours.ToString(); }
            else { dateArray[3] = "0" + hours.ToString(); }

            //minutes:
            minutes = (byte)(token / 60);
            token -= minutes * 60;
            if (minutes > 9) {dateArray[4] = minutes.ToString(); }
            else { dateArray[4]= "0" + minutes.ToString(); }

            //seconds:
            seconds = (byte)token;
            if (seconds > 9) { dateArray[5] =  seconds.ToString(); }
            else { dateArray[5] = "0" + seconds.ToString(); }

            return dateArray;
        }
    }
}

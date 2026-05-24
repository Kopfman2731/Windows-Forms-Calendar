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

        //Constructors

        public Date(long t)
        {
            this.timeToken = t;
        }

        public Date()
        {
            this.timeToken = 0;
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
            long leapDays, yearSeconds, year;
            int monthSeconds, daySeconds, hourSeconds, minuteSeconds, seconds;

            leapDays = timeToken / (4 * 31536000); //one leap day per 4 years
            if (leapDays >= 25) //=>100/4 = 25 leapDays per 100 years
            {
                leapDays -= leapDays / 25; //substract one for every leap years divisble by 100
            }
            if (leapDays >= 96) //=>(25-1)*4 = 96 leapDays per 400 years
            {
                leapDays += leapDays / 96; //add one for every leap year divisbile by 400
            }
            yearSeconds = 31536000 + leapDays * 86400;



            dateArray[0] = (timeToken / yearSeconds + 2000).ToString();
            dateArray[1] = (timeToken % yearSeconds / monthSeconds).ToString();
            dateArray[2] = (timeToken % (yearSeconds + monthSeconds) / daySeconds).ToString();
            dateArray[3] = (timeToken % (yearSeconds + monthSeconds + daySeconds) / hourSeconds).ToString();
            dateArray[4] = (timeToken % (yearSeconds + monthSeconds + daySeconds + hourSeconds) / minuteSeconds).ToString();
            dateArray[5] = (timeToken % (yearSeconds + monthSeconds + daySeconds + hourSeconds + minuteSeconds)).ToString();

            return dateArray;
        }
    }
}

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

        public DateTime(DateTime dt)
        {
            this.timeToken = dt.timeToken;
        }

        public DateTime(string s, int f = 0)// eg. YYYY-MM-DDThh:mm:ss
        {
            List<string> list = (List<string>)s.Split('-', 'T', ':', '.', ' ', '/').ToList();
            string tmp;
            //f == 0: YMD
            //f == 1: DMY
            //f == 2: MDY
            if (f == 1)
            {
                tmp = list[0];
                list[0] = list[2];
                list[2] = tmp;
            }
            else if (f == 2)
            {
                tmp = list[0];
                list[0] = list[2];
                list[2] = list[1];
                list[1] = tmp;
            }
            this.timeToken = ListToTimeToken(list);
        }

        //Methods
        //seconds in a day: 86400
        //seconds in a month
        //28 days: 2419200
        //29 days: 2505600
        //30 days: 2592000
        //31 days: 2678400
        //seconds in a regular year: 31536000

        private long ListToTimeToken(List<string> list) //calculate all the seconds
        {
            long t = 0, years, leapDays;
            byte months, days, hours, minutes, seconds;

            long.TryParse(list[0], out years);
            byte.TryParse(list[1], out months);
            byte.TryParse(list[2], out days);
            byte.TryParse(list[3], out hours); //maybe list.Count < 3 possible??? <<<<<<<<<<<====================== REVISIT
            byte.TryParse(list[4], out minutes);
            byte.TryParse(list[5], out seconds);

            years -= 2000;
            
            leapDays = years / 4;
            leapDays -= years / 100;
            leapDays += years / 400;

            //regular years:
            t += years * 31536000;
            //add leap day for this year:
            //since years are zero based, starting with 2000, in DateTime, when years are divided by 4, every 1st year is a leap years instead of every 4th
            if (years % 4 > 0 || (months > 2 || (months == 2 && days == 29))) { leapDays += 1; }
            //months:
            switch (months)
            {
                case 1:
                    t += 2678400;
                    break;
                case 2:
                    t += 5097600;
                    break;
                case 3:
                    t += 7776000;
                    break;
                case 4:
                    t += 10368000;
                    break;
                case 5:
                    t += 13046400;
                    break;
                case 6:
                    t += 15724800;
                    break;
                case 7:
                    t += 18403200;
                    break;
                case 8:
                    t += 21081600;
                    break;
                case 9:
                    t += 23673600;
                    break;
                case 10:
                    t += 26352000;
                    break;
                case 11:
                    t += 28944000;
                    break;
                case 12:
                    t += 31622400;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(months));
            }

            //days:
            t += (days + leapDays) * 86400;

            //hours:
            t += hours * 3600;

            //minutes:
            t += minutes * 60;

            //seconds:
            t += seconds;

            return t;
        }

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

        public List<string> GetDateTimeList() //returns string[6] with [0] == YYYY, [1] == MM, [2] == DD, [3] == hh, [4] == mm, [5] == ss
        {

            List<string> dateTimeList = new List<string>();
            long years, leapDays, token = TimeToken;
            int leapSeconds, monthSeconds;
            byte days, hours, minutes, seconds;

            //years:
            leapDays = token / (31536000 * 4 + 86400); //number of leapdays in token
            token -= leapDays * 86400; //substract leapdays from token
            years = token / 31536000 + 2000; //number of years can now be calculated easily
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

            //if DateEntry does not use time, then token == 1
            if (token == 1)
            {
                dateTimeList.Add("00");
                dateTimeList.Add("00");
                dateTimeList.Add("01");
                return dateTimeList;
            }

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

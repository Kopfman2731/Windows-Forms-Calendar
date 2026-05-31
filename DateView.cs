using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Calendar
{
    internal class DateView
    {
        private List<Date> dates; //should hold 42 = 6 rows * 7 columns Dates in month-view and 7 in week view
        private string month;
        private string year;
        private byte offset; //offset in days for which listBox contains the first of the month

        //Getter, Setter:

        public List<Date> Dates { get => dates; set => dates = value; }
        public string Month { get => month; set => month = value; }
        public string Year { get => year; set => year = value; }
        public byte Offset { get => offset; set => offset = value; }

        //Constructors:

        public DateView() : this(token) //default dateView is of the current month //WHYWHYWHY this is so stupid
        {
            DateTime localTime = new DateTime();
            string localDate = localTime.ToString("de-DE");
            //convert into my own format:
            DateTimeToken token = new DateTimeToken(localDate, 1);
            //this.DateView(token);
        }

        public DateView(DateTimeToken token)
        {
            //get local date and time:
            dates = new List<Date>();
            
            //create DateView fields:
            month = token.GetMonth();
            year = token.GetYear();
            //calculate offset:
            offset = CalculateOffset(token);
        }

        //Methods:

        private byte CalculateOffset(DateTimeToken timeToken)
        {
            string day = timeToken.GetDayName();
            switch (day)
            {
                case "Monday":
                    return 7;
                case "Tuesday":
                    return 1;
                case "Wednesday":
                    return 2;
                case "Thursday":
                    return 3;
                case "Friday":
                    return 4;
                case "Saturday":
                    return 5;
                case "Sunday":
                    return 6;
                default:
                    return 0;
            }
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    internal class DateView
    {
        private List<Date> dates; //should hold 42 = 6 rows * 7 columns Dates in month-view and 7 in week view
        private string month;
        private string year;
        private int offset; //offset in days for which listBox contains the first of the month

        //Getter, Setter:

        public List<Date> Dates { get => dates; set => dates = value; }
        public string Month { get => month; set => month = value; }
        public string Year { get => year; set => year = value; }
        public int Offset { get => offset; set => offset = value; }

        //Constructors:

        public DateView()
        {
            dates = new List<Date>();
        }

        //Methods:
    }
}

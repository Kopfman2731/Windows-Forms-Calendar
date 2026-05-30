using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    internal class Date
    {
        List<DateEntry> entries;
        byte day;
        byte month;
        long year;

        //Constructors

        public Date(DateTime dt, byte offset = 0)
        {
            DateTime dateTime;
            if (offset != 0)
            {
                dateTime = new DateTime();
            }
            else
            {
                dateTime = dt;
            }
                List<string> list = dateTime.GetDateTimeList(3);
            long.TryParse(list[0], out year);
            byte.TryParse(list[1], out month);
            byte.TryParse(list[2], out day);
            entries = null;
        }



        //Getter, Setter:

        public byte Day { get => day; set => day = value; }
        public byte Month { get => month; set => month = value; }
        public long Year { get => year; set => year = value; }
        internal List<DateEntry> Entries { get => entries; set => entries = value; }
    }
}

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
        short year;

        //Constructors

        public Date(DateTime dt) //should be the first second of the day, as in 00:00:00
        {
            List<string> list = dt.GetDateTimeList(3);
            short.TryParse(list[0], out year);
            byte.TryParse(list[1], out month);
            byte.TryParse(list[2], out day);
            entries = null;
        }



        //Getter, Setter:

        public byte Day { get => day; set => day = value; }
        public byte Month { get => month; set => month = value; }
        public short Year { get => year; set => year = value; }
        internal List<DateEntry> Entries { get => entries; set => entries = value; }
    }
}

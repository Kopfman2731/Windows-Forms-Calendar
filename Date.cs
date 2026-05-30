using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    internal class Date
    {
        private List<DateEntry> entries;
        private byte day;
        private byte month;
        private long year;

        //Constructors

        public Date(DateTimeToken dt, byte offset = 0) //optional offset by +/- days
        {
            DateTimeToken dateTime;
            if (offset != 0)
            {
                dateTime = new DateTimeToken(dt.TimeToken + offset * 86400);
            }
            else
            {
                dateTime = dt;
            }
            List<string> list = dateTime.GetList(3);
            long.TryParse(list[0], out year);
            byte.TryParse(list[1], out month);
            byte.TryParse(list[2], out day);
            entries = new List<DateEntry>();
        }

        //Getter, Setter:

        public byte Day { get => day; set => day = value; }
        public byte Month { get => month; set => month = value; }
        public long Year { get => year; set => year = value; }
        internal List<DateEntry> Entries { get => entries; set => entries = value; }
    }
}

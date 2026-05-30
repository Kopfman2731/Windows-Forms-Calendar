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
            string getDay = dateTime.GetDay();
            byte.TryParse(getDay, out day);
            entries = new List<DateEntry>();
        }

        //Getter, Setter:

        public byte Day { get => day; set => day = value; }

        internal List<DateEntry> Entries { get => entries; set => entries = value; }
    }
}

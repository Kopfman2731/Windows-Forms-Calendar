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

        public Date(DateTime dt) //must be the first second of the day
        {
            
        }

        //Getter, Setter:

        public byte Day { get => day; set => day = value; }
        public byte Month { get => month; set => month = value; }
        public short Year { get => year; set => year = value; }
        internal List<DateEntry> Entries { get => entries; set => entries = value; }
    }
}

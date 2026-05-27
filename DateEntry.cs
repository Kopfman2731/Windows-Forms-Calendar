using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    internal class DateEntry
    {
        private string title;
        private DateTime start; //if just the date, set to the first second of the day
        private DateTime end; //optional - if set, gives duration and activates startTime
        private DateTime reminder; //optional
        private bool usesTime; // determine if time should be used, or just the date
        //private int dateFormat; //0 = YMD, 1 = DMY, 2 = MDY
        //private bool limeyTimeFormat; // false = 00:00, true = 12.00 p.m.

        //Constructors:

        public DateEntry (string t, DateTime s, bool st) //minimal constructor, saves date and ,if st == true, time
        {
            title = t;
            start = s;
            end = null;
            reminder = null;
            usesTime = st;
        }

        public DateEntry (string t, DateTime s, DateTime e) //reduced constructor, saves date, time and duration
        {
            title = t;
            start = s;
            end = e;
            reminder = null;
            usesTime = true;
        }

        public DateEntry (string t, DateTime s, DateTime e, DateTime r) //full constructor, saves date, time and a reminder
        {
            title = t;
            start = s;
            end = e;
            reminder = r;
            usesTime = true;
        }

        // Getter, Setter:

        public string Titel { get { return title; } set { title = value; } }
        public DateTime Start { get { return start; } set { start = value; } }
        public DateTime End { get { return end; } set { end = value; }  }
        public DateTime Reminder { get { return reminder; } set { reminder = value; } }
        public bool UsesTime { get { return usesTime; } set { usesTime = value; } }

        //Methods:


    }
}

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
        private DateTimeToken start; //if just the date, set to the first second of the day
        private DateTimeToken end; //optional - DateTime of end
        private DateTimeToken reminder; //optional
        private bool usesTime; // determine if time should be used, or just the date
        //private int dateFormat; //0 = YMD, 1 = DMY, 2 = MDY
        //private bool limeyTimeFormat; // false = 00:00, true = 12.00 p.m.

        //Constructors:

        public DateEntry (string t, DateTimeToken s, bool st) //minimal constructor, saves date and ,if st == true, time
        {
            title = t;
            start = s;
            end = null;
            reminder = null;
            usesTime = st;
        }

        public DateEntry (string t, DateTimeToken s, DateTimeToken e) //reduced constructor, saves date, time and duration
        {
            title = t;
            start = s;
            end = e;
            reminder = null;
            usesTime = true;
        }

        public DateEntry (string t, DateTimeToken s, DateTimeToken e, DateTimeToken r) //full constructor, saves date, time and a reminder
        {
            title = t;
            start = s;
            end = e;
            reminder = r;
            usesTime = true;
        }

        // Getter, Setter:

        public string Titel { get { return title; } set { title = value; } }
        public DateTimeToken Start { get { return start; } set { start = value; } }
        public DateTimeToken End { get { return end; } set { end = value; }  }
        public DateTimeToken Reminder { get { return reminder; } set { reminder = value; } }
        public bool UsesTime { get { return usesTime; } set { usesTime = value; } }

        //Methods:

        public List<string> GetDate()// YYYY,MM,DD
        {
            List<string> list = start.GetList();
            list.RemoveRange(3, 3);
            return list;
        }

        public List<string> GetTime()// hh,mm,ss 
        {
            List<string> list = start.GetList();
            list.RemoveRange(0, 3);
            return list;
        }

        public List<string> GetDateTimeList()// YYYY,MM,DD,hh,mm,ss
        {
            return start.GetList();
        }
    }
}

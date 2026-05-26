using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalender
{
    internal class Entry
    {
        private string title;
        private Date start; //just the date, set to the first second of the day
        private Date end; //optional - if set, gives duration and activates startTime
        private Date reminder; //optional
        private bool startTime;
        //private bool useAlarm;
        //private int dateFormat; //0 = YMD, 1 = DMY, 2 = MDY
        //private bool limeyTimeFormat; // false = 00:00, true = 12.00 p.m.

        
        public Entry (string t, Date s, bool st) //minimal constructor, saves date and ,if st == true, time
        {
            title = t;
            start = s;
            startTime = st;
        }

        public Entry (string t, Date s, Date e) //reduced constructor, saves date, time and duration
        {
            title = t;
            start = s;
            end = s;
        }

        public Entry (string t, Date s, Date e, Date r) //full constructor, saves date, time and a reminder
        {
            title = t;
            start = s;
            end = e;
            reminder = r;
            startTime = true;
        }

        public string Titel { get { return title; } set { title = value; } }
        public Date Start { get { return start; } set { start = value; } }
        public Date End { get { return end; } set { end = value; }  }
        public Date Reminder { get { return reminder; } set { reminder = value; } }
        public bool StartTime { get { return startTime; } set { startTime = value; } }

    }
}

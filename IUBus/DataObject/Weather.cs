using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUBus.DataObject
{
    public class Weather : BaseDataObject
    {
        private DateTime mDate;
        private int mMinTemp;
        private string mPrecipitation;
        private string mEvents;

        public DateTime Date
        {
            get { return mDate; }
            set { mDate = value; }
        }
        public string DateString
        {
            get { return mDate.ToShortDateString(); }
        }

        public int MinTemp
        {
            get { return mMinTemp; }
            set { mMinTemp = value; }
        }

        public string Precipitation
        {
            get { return mPrecipitation; }
            set { mPrecipitation = value; }
        }

        public string Events
        {
            get { return mEvents; }
            set { mEvents = value; }
        }
    }
}

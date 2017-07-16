using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUBus.DataObject
{
    public class BusStop : BaseDataObject
    {
        private string mName;
        private bool mIsMajorStop;
        private double mLatitude;
        private double mLongitude;

        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        public bool IsMajorStop
        {
            get { return mIsMajorStop; }
            set { mIsMajorStop = value; }
        }

        public double Latitude
        {
            get { return mLatitude; }
            set { mLatitude = value; }
        }

        public double Longitude
        {
            get { return mLongitude; }
            set { mLongitude = value; }
        }

        public string Buddy { get; set; }
        public bool Visible { get; set; }
        public bool Announce { get; set; }
    }
}

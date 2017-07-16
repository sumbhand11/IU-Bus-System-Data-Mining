using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUBus.DataObject
{
    public class Interval : BaseDataObject
    {
        private int mBusID;
        private Bus mBusObj;
        private int mRouteID;
        private Route mRouteObj;
        private RouteDetail mRouteDetail;
        private int mFromBusStopID;
        private BusStop mFromBusStopObj;
        private int mToBusStopID;
        private BusStop mToBusStopObj;
        private bool mIsStationary;
        private int mTimeInterval;
        private DateTime mTimestamp;
        private int mMinTemp;
        private string mPrecipitation;
        private string mEvents;
        public string RouteName;
        public int BusID
        {
            get { return mBusID; }
            set { mBusID = value; }
        }

        public Bus BusObj
        {
            get { return mBusObj; }
            set { mBusObj = value; }
        }

        public int RouteID
        {
            get { return mRouteID; }
            set { mRouteID = value; }
        }

        public Route RouteObj
        {
            get { return mRouteObj; }
            set
            {
                mRouteObj = value;
                if (mRouteObj != null)
                    RouteID = mRouteObj.ID.Value;
            }
        }

        public RouteDetail RouteDetailObj
        {
            get { return mRouteDetail; }
            set { mRouteDetail = value; }
        }

        public int RouteDetailID
        {
            get { return mRouteDetail == null ? 0 : mRouteDetail.ID.Value; }
        }
        public int FromBusStopID
        {
            get { return mFromBusStopID; }
            set { mFromBusStopID = value; }
        }

        public BusStop FromBusStopObj
        {
            get { return mFromBusStopObj; }
            set { mFromBusStopObj = value; }
        }

        public int ToBusStopID
        {
            get { return mToBusStopID; }
            set { mToBusStopID = value; }
        }

        public BusStop ToBusStopObj
        {
            get { return mToBusStopObj; }
            set { mToBusStopObj = value; }
        }

        public bool IsStationary
        {
            get { return mIsStationary; }
            set { mIsStationary = value; }
        }

        public int TimeInterval
        {
            get { return mTimeInterval; }
            set { mTimeInterval = value; }
        }

        public DateTime Timestamp
        {
            get { return mTimestamp; }
            set { mTimestamp = value; }
        }

        public string Day
        {
            get
            {
                if (Timestamp != null)
                {
                    return Timestamp.DayOfWeek.ToString();
                }

                return String.Empty;
            }
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

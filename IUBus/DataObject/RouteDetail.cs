using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUBus.DataObject
{
    public class RouteDetail : BaseDataObject
    {
        public int RouteID;
        public int Sequence;
        public int FromBusStopID;
        public BusStop FromBusStop;
        public int ToBusStopID;
        public BusStop ToBusStop;
        public bool IsStationary;
        public double Distance;
        public int IdealTravelTime;
        public int ScheduledStopTime;
        public int ScheduledTravelTime;

        public int StopTime
        {
            get
            {
                if (ToBusStop.IsMajorStop == true)
                    return 60;
                else
                    return 30;
            }
        }
    }
}

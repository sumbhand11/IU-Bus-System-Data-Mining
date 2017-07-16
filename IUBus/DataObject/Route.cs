using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUBus.DataObject
{
    public class Route : BaseDataObject
    {
        private string mName;
        private bool mIsMtoR;

        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        public bool IsMtoR
        {
            get { return mIsMtoR; }
            set { mIsMtoR = value; }
        }

        public string RouteDetail;
        public List<RouteDetail> RouteDetails;
    }
}

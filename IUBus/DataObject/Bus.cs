using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUBus.DataObject
{
    public class Bus : BaseDataObject
    {
        private string mDescription;

        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace IUBus.AccessDB
{
    public static class AccessEngine
    {
        private static string mAccessFilePath = "DoublemapDataV2.accdb";
        private static string mAccessFilePath2 = "Ridership+Fall+2014.mdb";

        private static OleDbConnection mDBConnection;
        public static OleDbConnection DBConnection
        {
            get
            {
                return mDBConnection ?? (OpenDBConnection());
            }
        }

        private static OleDbConnection OpenDBConnection()
        {
            mDBConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + mAccessFilePath);
            mDBConnection.Open();
            return mDBConnection;
        }

        public static void CloseDBConnection()
        {
            if (mDBConnection != null)
                mDBConnection.Close();
        }

        public static DataSet Get(string queryString)
        {
            OleDbCommand cmd = new OleDbCommand(queryString, DBConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            return dataSet;
        }
    }
}

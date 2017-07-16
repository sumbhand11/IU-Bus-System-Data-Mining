using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

using IUBus.AccessDB;
using IUBus.SQLDB;
using IUBus.MySQL;
using IUBus.DataObject;
using IUBus.Utility;

namespace IUBus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            bool IsMySQLDB = true;

            DataSet busDataSet = AccessEngine.Get("SELECT DISTINCT(bus_id) FROM [IntervalData2014-2015]");
            DataSet intervalDataSet = AccessEngine.Get("SELECT * FROM [IntervalData2014-2015]");
            DataSet routeDataSet = AccessEngine.Get("SELECT * FROM [Route ID]");
            DataSet stopDataSet = AccessEngine.Get("SELECT * FROM [Stop ID]");
            DataSet weatherDataSet = AccessEngine.Get("SELECT * FROM [Weather Data]");

            List<Bus> buses = new List<Bus>();
            foreach (DataRow row in busDataSet.Tables[0].Rows)
            {
                Bus bus = new Bus();
                bus.ID = SQLUtil.ParseID(row[0]);
                bus.Description = string.Empty;
                buses.Add(bus);
            }

            List<Route> routes = new List<Route>();
            foreach (DataRow row in routeDataSet.Tables[0].Rows)
            {
                Route route = new Route();
                route.ID = SQLUtil.ParseID(row["ID"]);
                string info = SQLUtil.ParseString(row["Route ID"]);
                string[] infoArray = info.Split(' ');
                if (infoArray.Length > 1 && infoArray[0].Length == 1)
                    route.Name = infoArray[0];
                else
                    route.Name = info;

                route.RouteDetail = info;

                if (route.RouteDetail.Contains("M-R"))
                    route.IsMtoR = true;
                else
                    route.IsMtoR = false;

                routes.Add(route);
            }

            List<RouteDetail> routeDetails = new List<RouteDetail>();
            List<string> lines = new List<string>();
            //Build each route.
            lines = CSVUtil.ReadCSV("A.csv");
            int ARouteID = routes.First(o => o.Name == lines[0].Substring(0, 1) && o.IsMtoR == true).ID.Value;
            for (int i = 2; i < lines.Count; i++) // Line 0 is route name and Line 1 is header
            {
                string[] line = lines[i].Split(',');
                RouteDetail rd = new RouteDetail();
                rd.RouteID = ARouteID;
                rd.Sequence = i - 1;
                rd.FromBusStopID = int.Parse(line[0]);
                rd.ToBusStopID = int.Parse(line[1]);
                if (rd.FromBusStopID == rd.ToBusStopID)
                    rd.IsStationary = true;
                else
                    rd.IsStationary = false;

                rd.Distance = double.Parse(line[2]);
                rd.IdealTravelTime = int.Parse(line[3]);
                rd.ScheduledTravelTime = int.Parse(line[3]);
                if (rd.IsStationary)
                    rd.ScheduledStopTime = int.Parse(line[3]);

                routeDetails.Add(rd);
            }

            lines.Clear();
            lines = CSVUtil.ReadCSV("B.csv");
            int BRouteID = routes.First(o => o.Name == lines[0].Substring(0, 1) && o.IsMtoR == true).ID.Value;
            for (int i = 2; i < lines.Count; i++) // Line 0 is route name and Line 1 is header
            {
                string[] line = lines[i].Split(',');
                RouteDetail rd = new RouteDetail();
                rd.RouteID = BRouteID;
                rd.Sequence = i - 1;
                rd.FromBusStopID = int.Parse(line[0]);
                rd.ToBusStopID = int.Parse(line[1]);
                if (rd.FromBusStopID == rd.ToBusStopID)
                    rd.IsStationary = true;
                else
                    rd.IsStationary = false;

                rd.Distance = double.Parse(line[2]);
                rd.IdealTravelTime = int.Parse(line[3]);
                rd.ScheduledTravelTime = int.Parse(line[3]);
                if (rd.IsStationary)
                    rd.ScheduledStopTime = int.Parse(line[3]);

                routeDetails.Add(rd);
            }

            lines.Clear();
            lines = CSVUtil.ReadCSV("E.csv");
            int ERouteID = routes.First(o => o.Name == lines[0].Substring(0, 1) && o.IsMtoR == true).ID.Value;
            for (int i = 2; i < lines.Count; i++) // Line 0 is route name and Line 1 is header
            {
                string[] line = lines[i].Split(',');
                RouteDetail rd = new RouteDetail();
                rd.RouteID = ERouteID;
                rd.Sequence = i - 1;
                rd.FromBusStopID = int.Parse(line[0]);
                rd.ToBusStopID = int.Parse(line[1]);
                if (rd.FromBusStopID == rd.ToBusStopID)
                    rd.IsStationary = true;
                else
                    rd.IsStationary = false;

                rd.Distance = double.Parse(line[2]);
                rd.IdealTravelTime = int.Parse(line[3]);
                rd.ScheduledTravelTime = int.Parse(line[3]);
                if (rd.IsStationary)
                    rd.ScheduledStopTime = int.Parse(line[3]);

                routeDetails.Add(rd);
            }

            lines.Clear();
            lines = CSVUtil.ReadCSV("X.csv");
            int XRouteID = routes.First(o => o.Name == lines[0].Substring(0, 1) && o.IsMtoR == true).ID.Value;
            for (int i = 2; i < lines.Count; i++) // Line 0 is route name and Line 1 is header
            {
                string[] line = lines[i].Split(',');
                RouteDetail rd = new RouteDetail();
                rd.RouteID = ERouteID;
                rd.Sequence = i - 1;
                rd.FromBusStopID = int.Parse(line[0]);
                rd.ToBusStopID = int.Parse(line[1]);
                if (rd.FromBusStopID == rd.ToBusStopID)
                    rd.IsStationary = true;
                else
                    rd.IsStationary = false;

                rd.Distance = double.Parse(line[2]);
                rd.IdealTravelTime = int.Parse(line[3]);
                rd.ScheduledTravelTime = int.Parse(line[3]);
                if (rd.IsStationary)
                    rd.ScheduledStopTime = int.Parse(line[3]);

                routeDetails.Add(rd);
            }

            List<BusStop> busStops = new List<BusStop>();
            //foreach (DataRow row in stopDataSet.Tables[0].Rows)
            //{
            //    BusStop busStop = new BusStop();
            //    busStop.ID = SQLUtil.ParseID(row["ID"]);
            //    busStop.Name = SQLUtil.ParseString(row["Stop"]);
            //    busStop.IsMajorStop = false;

            //    busStops.Add(busStop);
            //}

            lines.Clear();
            lines = CSVUtil.ReadCSV("Combined GPS Data.csv");
            for (int i = 1; i < lines.Count; i++) // Line 0 is header
            {
                string[] line = lines[i].Split(',');
                BusStop busStop = new BusStop();
                busStop.ID = int.Parse(line[0]);
                busStop.Name = line[1];
                busStop.Latitude = double.Parse(line[2]);
                busStop.Longitude = double.Parse(line[3]);
                busStop.Buddy = line[4];
                if (line[5].ToLower() == "yes")
                    busStop.Visible = true;
                else
                    busStop.Visible = false;

                if (line[6].ToLower() == "yes")
                    busStop.Announce = true;
                else
                    busStop.Announce = false;

                busStops.Add(busStop);
            }


            List<Weather> weathers = new List<Weather>();
            foreach (DataRow row in weatherDataSet.Tables[0].Rows)
            {
                Weather weather = new Weather();
                weather.ID = SQLUtil.ParseID(row["ID"]);
                weather.Date = SQLUtil.ParseDateTime(row["EDT"]);
                weather.MinTemp = SQLUtil.ParseInt(row["MinTemp"]);
                weather.Precipitation = SQLUtil.ParseString(row["Precipitation"]);
                weather.Events = SQLUtil.ParseString(row["Events"]);

                weathers.Add(weather);
            }

            List<Interval> intervals = new List<Interval>();
            foreach (DataRow row in intervalDataSet.Tables[0].Rows)
            {
                Interval interval = new Interval();
                //interval.ID = SQLUtil.ParseID(row["ID1"]);
                interval.BusID = SQLUtil.ParseInt(row["bus_id"]);
                string routeName = SQLUtil.ParseString(row["route_id"]);
                if (routeName == "354")
                    routeName = "A";
                interval.RouteObj = routes.First(o => o.Name == routeName && o.IsMtoR == true);
                interval.FromBusStopID = SQLUtil.ParseInt(row["from"]);
                string toBusStop = SQLUtil.ParseString(row["to"]);
                interval.ToBusStopID = busStops.First(o => o.Name.ToLower().Contains(toBusStop.ToLower())).ID.Value;

                if (interval.FromBusStopID == interval.ToBusStopID)
                    interval.IsStationary = true;
                else
                    interval.IsStationary = false;

                interval.TimeInterval = SQLUtil.ParseInt(row["time"]);
                interval.Timestamp = SQLUtil.ParseDateTime(row["when"]);

                Weather temp = weathers.FirstOrDefault(o => o.DateString == interval.Timestamp.ToShortDateString());
                if (temp != null)
                {
                    interval.MinTemp = temp.MinTemp;
                    interval.Precipitation = temp.Precipitation;
                    interval.Events = temp.Events;
                }

                intervals.Add(interval);
            }

            DataTable rdDataTable;

            if (IsMySQLDB)
            {
                MySQLEngine.OpenDBConnection();
                MySqlCommand myCmd = new MySqlCommand();

                foreach (Bus bus in buses)
                {
                    myCmd.CommandText = "INSERT INTO TBL_Bus(ID, Description) VALUES (" + bus.ID + ", '" + bus.Description + "')";

                    MySQLEngine.ExecuteCommandText(myCmd);
                }

                foreach (Bus bus in buses)
                {
                    myCmd.CommandText = "INSERT INTO TBL_Bus(ID, Description) VALUES (" + bus.ID + ", '" + bus.Description + "')";

                    MySQLEngine.ExecuteCommandText(myCmd);
                }

                foreach (BusStop busStop in busStops)
                {
                    myCmd.CommandText = "INSERT INTO TBL_BusStop(ID, Name, IsMajorStop, Latitude, Longitude, Buddy, Visible, Announce) VALUES ("
                                    + busStop.ID + ", '" + busStop.Name.Replace("'", "''") + "', '" + busStop.IsMajorStop + "', "
                                    + busStop.Latitude + ", " + busStop.Longitude + ", '" + busStop.Buddy + "', '"
                                    + busStop.Visible + "', '" + busStop.Announce + "')";

                    MySQLEngine.ExecuteCommandText(myCmd);
                }

                foreach (Route route in routes)
                {
                    myCmd.CommandText = "INSERT INTO TBL_Route(ID, Name, RouteDetail, IsMtoR) VALUES (" + route.ID + ", '"
                                    + route.Name + "', '" + route.RouteDetail + "', '" + route.IsMtoR.ToString() + "')";

                    MySQLEngine.ExecuteCommandText(myCmd);
                }

                foreach (RouteDetail rd in routeDetails)
                {
                    myCmd.CommandText = "INSERT INTO TBL_RouteDetail(RouteID, Sequence, FromBusStopID, ToBusStopID, IsStationary, "
                                    + "Distance, IdealTravelTime, ScheduleStopTime, ScheduleTravelTime) VALUES ("
                                    + rd.RouteID + ", " + rd.Sequence + ", " + rd.FromBusStopID + ", " + rd.ToBusStopID
                                    + ", '" + rd.IsStationary + "', " + rd.Distance + ", " + rd.IdealTravelTime
                                    + ", " + rd.ScheduledStopTime + ", " + rd.ScheduledTravelTime + ")";

                    MySQLEngine.ExecuteCommandText(myCmd);
                    myCmd.CommandText = "SELECT MAX(ID) FROM TBL_RouteDetail";
                    rdDataTable = MySQLEngine.GetDataTableCommandText(myCmd);
                    rd.ID = SQLUtil.ParseID(rdDataTable.Rows[0][0]);
                }

                foreach (Interval interval in intervals)
                {
                    interval.RouteDetailObj = routeDetails.FirstOrDefault(o => o.FromBusStopID == interval.FromBusStopID &&
                                                o.ToBusStopID == interval.ToBusStopID && o.RouteID == interval.RouteID);
                    myCmd.CommandText = "INSERT INTO TBL_Interval(BusID, RouteID, RouteDetailID, FromBusStopID, ToBusStopID, "
                                        + "IsStationary, TimeInterval, Timestamp, Day, MinTemp, Precipitation, Events) VALUES ("
                                        + interval.BusID + ", " + interval.RouteID + ", " + interval.RouteDetailID + ", "
                                        + interval.FromBusStopID + ", " + interval.ToBusStopID + ", '" + interval.IsStationary + "', "
                                        + interval.TimeInterval + ", '" + interval.Timestamp.ToString() + "', '" + interval.Day + "', "
                                        + interval.MinTemp + ", '" + interval.Precipitation + "', '" + interval.Events + "')";
                    MySQLEngine.ExecuteCommandText(myCmd);
                }

                MySQLEngine.CloseDBConnection();
            }
            else
            {
                SQLEngine.OpenDBConnection();
                SqlCommand cmd = new SqlCommand();

                foreach (Bus bus in buses)
                {
                    cmd.CommandText = "INSERT INTO TBL_Bus(ID, Description) VALUES (" + bus.ID + ", '" + bus.Description + "')";

                    SQLEngine.ExecuteCommandText(cmd);
                }

                foreach (Bus bus in buses)
                {
                    cmd.CommandText = "INSERT INTO TBL_Bus(ID, Description) VALUES (" + bus.ID + ", '" + bus.Description + "')";

                    SQLEngine.ExecuteCommandText(cmd);
                }

                foreach (BusStop busStop in busStops)
                {
                    cmd.CommandText = "INSERT INTO TBL_BusStop(ID, Name, IsMajorStop, Latitude, Longitude, Buddy, Visible, Announce) VALUES ("
                                    + busStop.ID + ", '" + busStop.Name.Replace("'", "''") + "', '" + busStop.IsMajorStop + "', "
                                    + busStop.Latitude + ", " + busStop.Longitude + ", '" + busStop.Buddy + "', '"
                                    + busStop.Visible + "', '" + busStop.Announce + "')";

                    SQLEngine.ExecuteCommandText(cmd);
                }

                foreach (Route route in routes)
                {
                    cmd.CommandText = "INSERT INTO TBL_Route(ID, Name, RouteDetail, IsMtoR) VALUES (" + route.ID + ", '"
                                    + route.Name + "', '" + route.RouteDetail + "', '" + route.IsMtoR.ToString() + "')";

                    SQLEngine.ExecuteCommandText(cmd);
                }

                foreach (RouteDetail rd in routeDetails)
                {
                    cmd.CommandText = "INSERT INTO TBL_RouteDetail(RouteID, Sequence, FromBusStopID, ToBusStopID, IsStationary, "
                                    + "Distance, IdealTravelTime, ScheduleStopTime, ScheduleTravelTime) VALUES ("
                                    + rd.RouteID + ", " + rd.Sequence + ", " + rd.FromBusStopID + ", " + rd.ToBusStopID
                                    + ", '" + rd.IsStationary + "', " + rd.Distance + ", " + rd.IdealTravelTime
                                    + ", " + rd.ScheduledStopTime + ", " + rd.ScheduledTravelTime + ")";

                    SQLEngine.ExecuteCommandText(cmd);
                    cmd.CommandText = "SELECT MAX(ID) FROM TBL_RouteDetail";
                    rdDataTable = SQLEngine.GetDataTableCommandText(cmd);
                    rd.ID = SQLUtil.ParseID(rdDataTable.Rows[0][0]);
                }

                foreach (Interval interval in intervals)
                {
                    interval.RouteDetailObj = routeDetails.FirstOrDefault(o => o.FromBusStopID == interval.FromBusStopID &&
                                                o.ToBusStopID == interval.ToBusStopID && o.RouteID == interval.RouteID);
                    cmd.CommandText = "INSERT INTO TBL_Interval(BusID, RouteID, RouteDetailID, FromBusStopID, ToBusStopID, "
                                        + "IsStationary, TimeInterval, Timestamp, Day, MinTemp, Precipitation, Events) VALUES ("
                                        + interval.BusID + ", " + interval.RouteID + ", " + interval.RouteDetailID + ", "
                                        + interval.FromBusStopID + ", " + interval.ToBusStopID + ", '" + interval.IsStationary + "', "
                                        + interval.TimeInterval + ", '" + interval.Timestamp.ToString() + "', '" + interval.Day + "', "
                                        + interval.MinTemp + ", '" + interval.Precipitation + "', '" + interval.Events + "')";
                    SQLEngine.ExecuteCommandText(cmd);
                }

                SQLEngine.CloseDBConnection();
            }
        }
    }
}

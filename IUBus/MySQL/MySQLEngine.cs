using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace IUBus.MySQL
{
    public static class MySQLEngine
    {
        private static int cmdTimeout = 30;
        private static int retryCount = 3;
        public static String DatabaseName = "IUBusDB";

        private static MySqlConnection con;

        public static MySqlConnection OpenDBConnection()
        {
            int i = 0;
            while (i < retryCount)
            {
                i++;
                try
                {
                    con = new MySqlConnection("Server=LHP-LW7-HF6QCZ1\\SQLEXPRESS;Database=" + DatabaseName + ";UID=id;PASSWORD=password;");

                    if (con != null)
                    {
                        con.Open();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Open DB");
                    con = null;
                }
            }

            return con;
        }

        public static void CloseDBConnection()
        {
            try
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                //Joseph Lee 04/23/2014
                MessageBox.Show(ex.Message, "Close DB");
            }
        }

        /// <summary>
        /// Execute SqlCommand returning no result set.
        /// </summary>
        public static void ExecuteCommandText(MySqlCommand _cmd)
        {
            if (con == null && con.State != ConnectionState.Open)
            {
                try
                {
                    OpenDBConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Failed to open database connection.");
                }
            }

            if (con != null && con.State == ConnectionState.Open)
            {
                try
                {
                    _cmd.Connection = con;
                    _cmd.CommandType = CommandType.Text;
                    _cmd.CommandTimeout = cmdTimeout;

                    _cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "DB Error");
                }
            }
        }

        /// <summary>
        /// Access database and get data or execute command based on provided SqlCommand.
        /// </summary>
        public static DataTable GetDataTableCommandText(MySqlCommand _cmd)
        {
            if (con == null && con.State != ConnectionState.Open)
            {
                try
                {
                    OpenDBConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Failed to open database connection.");
                }
            }

            if (con != null && con.State == ConnectionState.Open)
            {
                try
                {
                    _cmd.Connection = con;
                    _cmd.CommandType = CommandType.Text;
                    _cmd.CommandTimeout = cmdTimeout;

                    MySqlDataAdapter da = new MySqlDataAdapter(_cmd);
                    using (DataSet ds = new DataSet())
                    {
                        da.Fill(ds);
                        return ds.Tables[0];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "DB Error");
                    return null;
                }
            }
            else
                return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace IUBus.SQLDB
{
    /// <summary>
    /// Data Access Engine for MS SQL Server.
    /// </summary>
    public static class SQLEngine
    {
        private static int cmdTimeout = 30;
        private static int retryCount = 3;
        public static String DatabaseName = "IUBusDB";

        private static SqlConnection con;

        public static SqlConnection OpenDBConnection()
        {
            int i = 0;
            while (i < retryCount)
            {
                i++;
                try
                {
                    con = new SqlConnection("Server=LHP-LW7-HF6QCZ1\\SQLEXPRESS;Database=" + DatabaseName + ";integrated security=SSPI;Connection Timeout=30");
                    
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
        public static void ExecuteCommandText(SqlCommand _cmd)
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

                    foreach (SqlParameter p in _cmd.Parameters)
                    {
                        if (p.Value == null)
                            p.Value = DBNull.Value;
                    }

                    _cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "DB Error");
                }
            }
        }

        /// <summary>
        /// Execute SqlCommand returning no result set.
        /// </summary>
        public static void ExecuteCommandStoredProcedure(SqlCommand _cmd)
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
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.CommandTimeout = cmdTimeout;

                    foreach (SqlParameter p in _cmd.Parameters)
                    {
                        if (p.Value == null)
                            p.Value = DBNull.Value;
                    }

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
        public static DataTable GetDataTableCommandText(SqlCommand _cmd)
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

                    SqlDataAdapter da = new SqlDataAdapter(_cmd);
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

        /// <summary>
        /// Access database and get data or execute command based on provided SqlCommand.
        /// </summary>
        public static DataTable GetDataTable(SqlCommand _cmd)
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
                    _cmd.CommandType = CommandType.StoredProcedure;
                    _cmd.CommandTimeout = cmdTimeout;

                    foreach (SqlParameter p in _cmd.Parameters)
                    {
                        if (p.Value == null)
                            p.Value = DBNull.Value;
                    }
                    SqlDataAdapter da = new SqlDataAdapter(_cmd);
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

        /// <summary>
        /// Access database and get data or execute command based on provided stored procedure.
        /// </summary>
        public static DataTable GetDataTable(string _sp)
        {
            SqlCommand cmd = new SqlCommand(_sp);
            return GetDataTable(cmd);
        }

        /// <summary>
        /// Access database and get data or execute command on a specific record based on provided stored procedure and ID.
        /// </summary>
        public static DataTable GetDataTable(string _sp, int _ID)
        {
            SqlCommand cmd = new SqlCommand(_sp);

            SqlParameter sqlParam = cmd.Parameters.Add("@ID", SqlDbType.Int);
            sqlParam.Direction = ParameterDirection.Input;
            sqlParam.Value = _ID;

            return GetDataTable(cmd);
        }

        /// <summary>
        /// Access database and get data or execute command on a specific record based on provided stored procedure and ID.
        /// </summary>
        public static DataTable GetDataTable(string _sp, int? _ID)
        {
            SqlCommand cmd = new SqlCommand(_sp);

            SqlParameter sqlParam = cmd.Parameters.Add("@ID", SqlDbType.Int);
            sqlParam.Direction = ParameterDirection.Input;
            sqlParam.Value = _ID;

            return GetDataTable(cmd);
        }

        /// <summary>
        /// Access database and get data or execute command based on provided stored procedure and list of SqlParameter.
        /// </summary>
        public static DataTable GetDataTable(string _sp, List<SqlParameter> _pList)
        {
            SqlCommand cmd = new SqlCommand(_sp);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = cmdTimeout;

            if (_pList != null && _pList.Count > 0)
            {
                cmd.Parameters.AddRange(_pList.ToArray());
            }

            return GetDataTable(cmd);
        }
    }
}


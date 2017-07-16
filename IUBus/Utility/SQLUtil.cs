using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUBus.Utility
{
    public static class SQLUtil
    {
        #region Parsing Methods

        public static Int32? ParseID(object obj)
        {
            try
            {
                if (obj == DBNull.Value)
                {
                    return null;
                }
                else
                {
                    return Convert.ToInt32(obj);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string ParseString(object obj)
        {
            try
            {
                if (obj == DBNull.Value)
                {
                    return String.Empty;
                }
                else
                {
                    return Convert.ToString(obj);
                }
            }
            catch (Exception ex)
            {
                return String.Empty;
            }
        }

        public static int ParseInt(object obj)
        {
            try
            {
                if (obj == DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(obj);
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static int? ParseNullableInt(object obj)
        {
            try
            {
                if (obj == DBNull.Value)
                {
                    return null;
                }
                else
                {
                    return Convert.ToInt32(obj);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Int64? ParseInt64(object obj)
        {
            try
            {
                if (obj == DBNull.Value)
                {
                    return null;
                }
                else
                {
                    return Convert.ToInt64(obj);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static double ParseDouble(object obj)
        {
            try
            {
                if (obj == DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToDouble(obj);
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static bool ParseBoolean(object obj)
        {
            try
            {
                if (obj == DBNull.Value)
                {
                    return false;
                }
                else
                {
                    return Convert.ToBoolean(obj);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool? ParseNullableBoolean(object obj)
        {
            try
            {
                if (obj == DBNull.Value)
                {
                    return null;
                }
                else
                {
                    return Convert.ToBoolean(obj);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string ParseShortDate(object obj)
        {
            try
            {
                if (obj == DBNull.Value)
                {
                    return null;
                }
                else
                {

                    return Convert.ToDateTime(obj).ToShortDateString();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static DateTime ParseDateTime(object obj)
        {
            try
            {
                if (obj == DBNull.Value)
                {
                    return DateTime.MinValue;
                }
                else
                {

                    return Convert.ToDateTime(obj);
                }
            }
            catch (Exception ex)
            {
                return DateTime.MinValue;
            }
        }
        #endregion
    }
}

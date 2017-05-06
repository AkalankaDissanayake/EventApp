using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public class DataAccessUtility
    {
        public static string DbNullToString(object value)
        {
            if (value == DBNull.Value || value == null)
            {
                return "";
            }
            return value.ToString();
        }
               
        public static int DbNullToInt32(object value)
        {
            if (value == DBNull.Value || value == null)
            {
                return 0;
            }
            return Convert.ToInt32(value);
        }
        public static DateTime DbNullToDateTime(object value)
        {
            if (value== DBNull.Value || value == null)
            {
                return new DateTime();
            }
            return Convert.ToDateTime(value);
        }
        public static bool DbNullToBool(object value)
        {
            if (value == DBNull.Value || value == null)
            {
                return false;
            }
            return Convert.ToBoolean(value);           
        }

        public static double DbNullToDouble(object value)
        {
            if (value == DBNull.Value || value == null)
            {
                return 0.00d;
            }
            return Convert.ToDouble(value);
        }

        public static decimal DbNullToDecimal(object value)
        {
            if (value == DBNull.Value || value == null)
            {
                return 0;
            }
            return Convert.ToDecimal(value);
        }

        public static byte[] DbNullToByteArr(object value)
        {
            if (value == null || DBNull.Value == value)
            {
                return null;
            }
            return (byte[])value;
        }

        public static DateTime? GetLocalDateTime(DateTime? d)
        {
            if (d == null)
            {
                return null;
            }
            return d.Value.ToLocalTime();
        }
    }
}

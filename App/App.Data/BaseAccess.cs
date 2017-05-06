using App.Entity;
using App.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public class BaseAccess
    {
        private IAppLogManager iAppLogManager;
        public BaseAccess()
        {
            iAppLogManager = new AppLogManager();
        }
        public ServiceResult<List<ReferenceData>> GetReferenceData(int type)
        {
            var rtnResult = new ServiceResult<List<ReferenceData>>();
            try
            {


                SqlCommand Cmd = new SqlCommand("GetReferenceData", ConnectionManager.Connection());
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.AddInputParameters(new { Xtype = type });
                SqlDataReader dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
                var rtn = new List<ReferenceData>();
                while (dr.Read())
                {
                    var itm = new ReferenceData();
                    itm.ID = DataAccessUtility.DbNullToInt32(dr["ID"]);
                    itm.Value = DataAccessUtility.DbNullToString(dr["Value"]);
                    rtn.Add(itm);
                }
                dr.Close();
                rtnResult.Result = rtn;
                rtnResult.ResultStatus = new Status(true);
                return rtnResult;
            }
            catch(Exception e)
            {
                iAppLogManager.WriteLog(e);
                rtnResult.ResultStatus = new Status(false);
                return rtnResult;
            }
            finally
            {
                ConnectionManager.Close();

            }

        }


    }

}

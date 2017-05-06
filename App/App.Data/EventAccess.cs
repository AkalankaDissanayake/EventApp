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
    public class EventAccess
    {
        private IAppLogManager iAppLogManager;
        public EventAccess()
        {
            iAppLogManager = new AppLogManager();
        }
        public ServiceResult<int> CreateBaseEvent(Event eventObj)
        {
            var rtnResult = new ServiceResult<int>();
            try
            {


                SqlCommand Cmd = new SqlCommand("AddEditEvent", ConnectionManager.Connection());
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.AddInputParameters(new
                        {
                        Address = eventObj.Address,
                        Address1 = eventObj.Address1,
                        City = eventObj.City,
                        Country = eventObj.Country,
                        CountryCode = eventObj.CountryCode,
                        EventDescription = eventObj.EventDescription,
                        EventEnd = eventObj.EventEnd,
                        EventID = eventObj.EventID,
                        EventImage = eventObj.EventImage,
                        EventStart = eventObj.EventStart,
                        Latitude = eventObj.Latitude,
                        Longitude = eventObj.Longitude,
                        Postcode = eventObj.Postcode,
                        StatusID = eventObj.StatusID,
                        Title = eventObj.Title,
                        VenueName = eventObj.VenueName,
                });
                SqlDataReader dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
                var rtn = 0;
                while (dr.Read())
                {
                    rtn = DataAccessUtility.DbNullToInt32(dr["EventID"]);
                }

                //dr.NextResult();

                //while (dr.Read())
                //{
                //    // populate your second object
                //}

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

        public ServiceResult<int> CreateEventTicket(Ticket ticket)
        {
            var rtnResult = new ServiceResult<int>();
            try
            {


                SqlCommand Cmd = new SqlCommand("AddEditEventTicket", ConnectionManager.Connection());
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.AddInputParameters(new
                {
                    EventTicketID = ticket.EventTicketID,
                    Name = ticket.Name,
                    Price = ticket.Price,
                    Quantity = ticket.Quantity,
                    Type = ticket.Type,
                    EventID = ticket.EventID,

                });
                SqlDataReader dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
                var rtn = 0;
                while (dr.Read())
                {
                    rtn = DataAccessUtility.DbNullToInt32(dr["EventTicketID"]);
                }

                dr.Close();
                rtnResult.Result = rtn;
                rtnResult.ResultStatus = new Status(true);
                return rtnResult;
            }
            catch (Exception e)
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

        public ServiceResult<Event> GetEvetntByID(int eventID)
        {
            var rtnResult = new ServiceResult<Event>();
            try
            {


                SqlCommand Cmd = new SqlCommand("GetEvetByID", ConnectionManager.Connection());
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.AddInputParameters(new
                {
                    EventID = eventID,
                });
                SqlDataReader dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
                var rtn = new Event();
                rtn.EventTicketList = new List<Ticket>();
                while (dr.Read())
                {
                    rtn.Address = DataAccessUtility.DbNullToString(dr["Address"]);
                    rtn.Address1 = DataAccessUtility.DbNullToString(dr["Address1"]);
                    rtn.City = DataAccessUtility.DbNullToString(dr["City"]);
                    rtn.Country = DataAccessUtility.DbNullToString(dr["Country"]);
                    rtn.CountryCode = DataAccessUtility.DbNullToString(dr["CountryCode"]);
                    rtn.EventDescription = DataAccessUtility.DbNullToString(dr["EventDescription"]);
                    rtn.EventEnd = DataAccessUtility.DbNullToDateTime(dr["EventEnd"]);
                    rtn.EventID = DataAccessUtility.DbNullToInt32(dr["EventID"]);
                    rtn.EventImage = DataAccessUtility.DbNullToByteArr(dr["EventImage"]);
                    rtn.EventStart = DataAccessUtility.DbNullToDateTime(dr["EventStart"]);
                    rtn.Latitude = DataAccessUtility.DbNullToString(dr["Latitude"]);
                    rtn.Longitude = DataAccessUtility.DbNullToString(dr["Longitude"]);
                    rtn.Postcode = DataAccessUtility.DbNullToString(dr["Postcode"]);
                    //rtn.Status = DataAccessUtility.DbNullToString(dr["Status"]);
                    rtn.StatusID = DataAccessUtility.DbNullToInt32(dr["StatusID"]);
                    rtn.Title = DataAccessUtility.DbNullToString(dr["Title"]);
                    rtn.VenueName = DataAccessUtility.DbNullToString(dr["VenueName"]);
                }

                dr.NextResult();
                var rtnList = new List<Ticket>();
                while (dr.Read())
                {
                    var itm = new Ticket();
                    itm.EventTicketID = DataAccessUtility.DbNullToInt32(dr["EventTicketID"]);
                    itm.Name = DataAccessUtility.DbNullToString(dr["Name"]);
                    itm.Price = DataAccessUtility.DbNullToDecimal(dr["Price"]);
                    itm.Quantity = DataAccessUtility.DbNullToInt32(dr["Quantity"]);
                    itm.Type = DataAccessUtility.DbNullToInt32(dr["Type"]);
                    rtnList.Add(itm);
                }

                rtn.EventTicketList = rtnList;
                dr.Close();
                rtnResult.Result = rtn;
                rtnResult.ResultStatus = new Status(true);
                return rtnResult;
            }
            catch (Exception e)
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

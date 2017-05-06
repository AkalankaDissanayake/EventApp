using App.Data;
using App.Entity;
using App.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Logic
{

    public class EventLogic
    {
        private EventAccess eventAccess;
        private IAppLogManager iAppLogManager;
        public EventLogic()
        {
            eventAccess = new EventAccess();
            iAppLogManager = new AppLogManager();
        }
        public ServiceResult<int> CreateEvent(Event eventObj)
        {
            try {

                var eventResult = eventAccess.CreateBaseEvent(eventObj);

                foreach(var ticket in eventObj.EventTicketList)
                {
                    ticket.EventID = eventResult.Result;
                    eventAccess.CreateEventTicket(ticket);

                }
                return eventResult;
            }
            catch (Exception e) {

                iAppLogManager.WriteLog(e);
                return new ServiceResult<int>();
            }            

        }

        public ServiceResult<Event> GetEvetntByID(int eventID)
        {
            return eventAccess.GetEvetntByID(eventID);
        }
    }
}

using App.Entity;
using App.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace App.UI.Controllers.Api
{
    public class EventController : ApiController
    {

        private EventLogic eventLogic;

        public EventController()
        {
            eventLogic = new EventLogic();
        }
        [System.Web.Http.HttpPost]
        [ValidateInput(false)]
        public ServiceResult<int> CreateEvent(Event eventObj)
        {
            var rtn = eventLogic.CreateEvent(eventObj);
            return rtn;
        }
        public ServiceResult<Event> GetEvetByID(int evenID)
        {
            var rtn = eventLogic.GetEvetntByID(evenID);
            return rtn;
        }
    }
}

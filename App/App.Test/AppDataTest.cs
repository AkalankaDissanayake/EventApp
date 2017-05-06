using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Data;
using App.Utility;
using App.Entity;

namespace App.Test
{
    [TestClass]
    public class AppDataTest
    {
        private BaseAccess baseAccess;

        private EventAccess eventAccess;
        public AppDataTest()
        {
            baseAccess = new BaseAccess();
            eventAccess = new EventAccess();
        }
        [TestMethod]
        public void DataReferenceDataGet()
        {
            var rtn = baseAccess.GetReferenceData(0);
            Assert.IsTrue(rtn.ResultStatus.IsSuccess == true);
            
        }
        [TestMethod]
        public void BaseEventCreateTest()
        {
            var eventObj = new Event();
            eventObj.Address = "yes";
            eventObj.City = "City";
            eventObj.EventStart = DateTime.Today;
            eventObj.EventEnd = DateTime.Now;
            eventObj.Country = "Sri Lanka";
            eventObj.EventDescription = "dummy content";

            var rtn = eventAccess.CreateBaseEvent(eventObj);
            Assert.IsTrue(rtn.ResultStatus.IsSuccess == true);

        }
        [TestMethod]
        public void GetEventByID()
        {
            var rtn = eventAccess.GetEvetntByID(4);
            Assert.IsTrue(rtn.ResultStatus.IsSuccess == true);

        }
        [TestMethod]
        public void EventTicketCreateTest()
        {
            var eventObj = new Event();
            eventObj.Address = "yes";
            eventObj.City = "City";
            eventObj.EventStart = DateTime.Today;
            eventObj.EventEnd = DateTime.Now;
            eventObj.Country = "Sri Lanka";
            eventObj.EventDescription = "dummy content";

            var rtn = eventAccess.CreateBaseEvent(eventObj);
            Ticket ticket = new Ticket();
            ticket.EventID = rtn.Result;
            var TicketResult = eventAccess.CreateEventTicket(ticket);
            Assert.IsTrue(TicketResult.ResultStatus.IsSuccess == true);

        }


    }
}

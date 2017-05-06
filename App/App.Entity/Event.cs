using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity
{
    public class Event
    {
        public int EventID { get; set; }
        public string Title { get; set; }
        public string VenueName { get; set; }
        public string Address { get; set; }
        public string Address1 { get; set; }
        public string CountryCode { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime? EventStart { get; set; }
        public DateTime? EventEnd { get; set; }

        public string EventDescription { get; set; }

        public List<Ticket> EventTicketList { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Status { get; set; }
        public int StatusID { get; set; }
        public DateTime? LastUpdated { get; set; }
        public byte[] EventImage { get; set; }
    }

    public class Ticket
    {
        public int EventTicketID { get; set; }

        public int EventID { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}

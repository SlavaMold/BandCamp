using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandCamp.Models
{
    public class Concert
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
        public DateTime Date { get; set; }
        public int TicketsSold { get; set; }
        public decimal TicketPrice { get; set; }
        public decimal Revenue => TicketsSold * TicketPrice;

        public override string ToString() => $"{City} — {Venue} ({Date:dd.MM.yyyy})";
    }
}

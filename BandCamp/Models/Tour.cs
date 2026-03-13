using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandCamp.Models
{
    public class Tour
    {
        public int Id { get; set; }
        public int BandId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Budget { get; set; }
        public string Country { get; set; }
        public List<Concert> Concerts { get; set; } = new List<Concert>();

        public override string ToString() => $"{Name} ({StartDate:dd.MM.yyyy} — {EndDate:dd.MM.yyyy})";
    }
}

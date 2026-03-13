using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandCamp.Models
{
    public class Band
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public DateTime FormationDate { get; set; }
        public string Description { get; set; }
        public List<Member> Members { get; set; } = new List<Member>();
        public List<Tour> Tours { get; set; } = new List<Tour>();

        public override string ToString() => $"{Name} ({Genre})";
    }
}

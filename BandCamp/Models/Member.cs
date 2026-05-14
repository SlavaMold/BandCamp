using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandCamp.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public int ExperienceYears { get; set; }
        public DateTime JoinDate { get; set; }
        public string PhotoPath { get; set; }
        public bool IsActive { get; set; } = true;
        public List<Band> Bands { get; set; } = new List<Band>();

        public string FullName => $"{FirstName} {LastName}".Trim();
        public override string ToString() => FullName;
    }
}

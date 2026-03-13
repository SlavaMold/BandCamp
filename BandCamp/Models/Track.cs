using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandCamp.Models
{
    public class Track
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int DurationSeconds { get; set; }
        public string Genre { get; set; }

        public string DurationFormatted =>
            $"{DurationSeconds / 60}:{DurationSeconds % 60:D2}";

        public override string ToString() => $"{Title} ({DurationFormatted})";
    }
}

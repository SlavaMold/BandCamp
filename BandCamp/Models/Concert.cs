using System;

namespace BandCamp.Models
{
    public class Concert
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BandId { get; set; }
        public string BandName { get; set; }
        public DateTime Date { get; set; }
        public string ResponsiblePerson { get; set; }
        public decimal Payment { get; set; }
        public string Comment { get; set; }
        public int? ContractId { get; set; }

        public override string ToString() =>
            $"{Name} — {BandName} ({Date:dd.MM.yyyy})";
    }
}
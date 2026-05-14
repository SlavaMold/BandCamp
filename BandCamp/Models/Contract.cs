using System;

namespace BandCamp.Models
{
    public enum ContractType
    {
        Recording,
        Concert,
        Tour
    }

    public class Contract
    {
        public int Id { get; set; }
        public ContractType Type { get; set; }
        public string StudioName { get; set; }
        public string ResponsiblePerson { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Payment { get; set; }
        public int BandId { get; set; }
        public string BandName { get; set; }
        public string ProductName { get; set; }

        public override string ToString() =>
            $"[{Type}] {ProductName} — {BandName} ({StartDate:dd.MM.yyyy})";
    }
}
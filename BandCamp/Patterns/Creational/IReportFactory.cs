namespace BandCamp.Patterns.Creational
{
    public interface IReportFactory
    {
        IReport CreateMembersReport(System.Collections.Generic.List<Models.Member> members);
        IReport CreateConcertsReport(System.Collections.Generic.List<Models.Concert> concerts);
        IReport CreateContractsReport(System.Collections.Generic.List<Models.Contract> contracts);
    }
}
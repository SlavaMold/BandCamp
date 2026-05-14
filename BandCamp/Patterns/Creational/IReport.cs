namespace BandCamp.Patterns.Creational
{
    public interface IReport
    {
        string Title { get; }
        string Generate();
    }
}
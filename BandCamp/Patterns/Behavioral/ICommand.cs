namespace BandCamp.Patterns.Behavioral
{
    public interface ICommand
    {
        void Execute();
        void Undo();
        string Description { get; }
        ICommand CreateFresh(); // создаёт новую команду с теми же данными
    }
}
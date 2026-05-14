using System.Collections.Generic;

namespace BandCamp.Patterns.Behavioral
{
    public class CommandManager
    {
        private static CommandManager _instance;
        private static readonly object _lock = new object();

        private readonly Stack<ICommand> _undoStack = new Stack<ICommand>();
        private readonly Stack<ICommand> _redoStack = new Stack<ICommand>();

        public static CommandManager Instance
        {
            get
            {
                if (_instance == null)
                    lock (_lock)
                        if (_instance == null)
                            _instance = new CommandManager();
                return _instance;
            }
        }

        private CommandManager() { }

        public bool CanUndo => _undoStack.Count > 0;
        public bool CanRedo => _redoStack.Count > 0;

        public string LastUndoDescription =>
            CanUndo ? _undoStack.Peek().Description : "";
        public string LastRedoDescription =>
            CanRedo ? _redoStack.Peek().Description : "";

        public void Execute(ICommand command)
        {
            command.Execute();
            _undoStack.Push(command);
            _redoStack.Clear();
        }

        public void Undo()
        {
            if (!CanUndo) return;
            var command = _undoStack.Pop();
            command.Undo();
            _redoStack.Push(command);
        }

        public void Redo()
        {
            if (!CanRedo) return;
            var command = _redoStack.Pop();
            // Redo создаёт свежую команду через фабричный метод
            var fresh = command.CreateFresh();
            fresh.Execute();
            _undoStack.Push(fresh);
        }

        public void Clear()
        {
            _undoStack.Clear();
            _redoStack.Clear();
        }
    }
}
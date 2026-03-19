using System;
using System.Collections.Generic;

namespace BandCamp.Patterns.Structural
{
    public abstract class MusicComponent
    {
        public string Name { get; protected set; }

        protected MusicComponent(string name)
        {
            Name = name;
        }

        public abstract void Display(int depth = 0);
        public virtual void Add(MusicComponent component) =>
            throw new NotSupportedException();
        public virtual void Remove(MusicComponent component) =>
            throw new NotSupportedException();
    }

    public class MusicTrack : MusicComponent
    {
        public int DurationSeconds { get; }

        public MusicTrack(string name, int durationSeconds)
            : base(name)
        {
            DurationSeconds = durationSeconds;
        }

        public override void Display(int depth = 0)
        {
            string indent = new string('-', depth);
            Console.WriteLine($"{indent} Трек: {Name} " +
                $"({DurationSeconds / 60}:{DurationSeconds % 60:D2})");
        }
    }

    public class MusicAlbum : MusicComponent
    {
        private readonly List<MusicComponent> _tracks = new List<MusicComponent>();
        public IReadOnlyList<MusicComponent> Children => _tracks;

        public MusicAlbum(string name) : base(name) { }

        public override void Add(MusicComponent component) =>
            _tracks.Add(component);

        public override void Remove(MusicComponent component) =>
            _tracks.Remove(component);

        public override void Display(int depth = 0)
        {
            string indent = new string('-', depth);
            Console.WriteLine($"{indent} Альбом: {Name} ({_tracks.Count} треков)");
            foreach (var t in _tracks)
                t.Display(depth + 2);
        }
    }

    public class BandCatalog : MusicComponent
    {
        private readonly List<MusicComponent> _albums = new List<MusicComponent>();
        public IReadOnlyList<MusicComponent> Children => _albums;

        public BandCatalog(string bandName) : base(bandName) { }

        public override void Add(MusicComponent component) =>
            _albums.Add(component);

        public override void Remove(MusicComponent component) =>
            _albums.Remove(component);

        public override void Display(int depth = 0)
        {
            Console.WriteLine($"Каталог группы: {Name}");
            foreach (var a in _albums)
                a.Display(depth + 2);
        }
    }
}
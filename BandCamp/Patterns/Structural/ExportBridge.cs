using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using BandCamp.Models;

namespace BandCamp.Patterns.Structural
{
    // Implementor — куда экспортируем
    public interface IExportRenderer
    {
        void Render(string title, List<string[]> rows, string[] headers);
    }

    // Concrete Implementor 1 — CSV
    public class CsvExportRenderer : IExportRenderer
    {
        private readonly string _filePath;

        public CsvExportRenderer(string filePath)
        {
            _filePath = filePath;
        }

        public void Render(string title, List<string[]> rows, string[] headers)
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Join(";", headers));
            foreach (var row in rows)
                sb.AppendLine(string.Join(";", row));
            File.WriteAllText(_filePath, sb.ToString(), Encoding.UTF8);
        }
    }

    // Concrete Implementor 2 — текстовый предпросмотр
    public class TextPreviewRenderer : IExportRenderer
    {
        public string Result { get; private set; }

        public void Render(string title, List<string[]> rows, string[] headers)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"=== {title} ===");
            sb.AppendLine(string.Join(" | ", headers));
            sb.AppendLine(new string('-', 40));
            foreach (var row in rows)
                sb.AppendLine(string.Join(" | ", row));
            Result = sb.ToString();
        }
    }

    // Abstraction — что экспортируем
    public abstract class DataExporter
    {
        protected IExportRenderer Renderer;

        protected DataExporter(IExportRenderer renderer)
        {
            Renderer = renderer;
        }

        public abstract void Export();
    }

    // Refined Abstraction 1 — экспорт участников
    public class MembersExporter : DataExporter
    {
        private readonly List<Member> _members;

        public MembersExporter(List<Member> members, IExportRenderer renderer)
            : base(renderer)
        {
            _members = members;
        }

        public override void Export()
        {
            var headers = new[] { "Имя", "Роль", "Дата вступления", "Активен" };
            var rows = new List<string[]>();
            foreach (var m in _members)
                rows.Add(new[]
                {
                    m.FullName,
                    m.Role,
                    m.JoinDate.ToString("dd.MM.yyyy"),
                    m.IsActive ? "Да" : "Нет"
                });
            Renderer.Render("Участники группы", rows, headers);
        }
    }

    // Refined Abstraction 2 — экспорт туров
    public class ToursExporter : DataExporter
    {
        private readonly List<Tour> _tours;

        public ToursExporter(List<Tour> tours, IExportRenderer renderer)
            : base(renderer)
        {
            _tours = tours;
        }

        public override void Export()
        {
            var headers = new[] { "Название", "Страна", "Начало", "Конец", "Бюджет" };
            var rows = new List<string[]>();
            foreach (var t in _tours)
                rows.Add(new[]
                {
                    t.Name,
                    t.Country,
                    t.StartDate.ToString("dd.MM.yyyy"),
                    t.EndDate.ToString("dd.MM.yyyy"),
                    t.Budget.ToString("F2")
                });
            Renderer.Render("Туры группы", rows, headers);
        }
    }
}
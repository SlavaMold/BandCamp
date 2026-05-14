using System.Collections.Generic;
using System.IO;
using System.Text;
using BandCamp.Models;

namespace BandCamp.Patterns.Creational
{
    // ---- Конкретные продукты — CSV отчёты ----

    public class CsvMembersReport : IReport
    {
        private readonly List<Member> _members;
        private readonly string _filePath;
        public string Title => "Отчёт по участникам (CSV)";

        public CsvMembersReport(List<Member> members, string filePath)
        {
            _members = members;
            _filePath = filePath;
        }

        public string Generate()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Имя;Роль;Опыт (лет);Активен");
            foreach (var m in _members)
                sb.AppendLine($"{m.FullName};{m.Role};{m.ExperienceYears};{(m.IsActive ? "Да" : "Нет")}");
            File.WriteAllText(_filePath, sb.ToString(), Encoding.UTF8);
            return $"CSV сохранён: {_filePath}";
        }
    }

    public class CsvConcertsReport : IReport
    {
        private readonly List<Concert> _concerts;
        private readonly string _filePath;
        public string Title => "Отчёт по концертам (CSV)";

        public CsvConcertsReport(List<Concert> concerts, string filePath)
        {
            _concerts = concerts;
            _filePath = filePath;
        }

        public string Generate()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Название;Группа;Дата;Оплата");
            foreach (var c in _concerts)
                sb.AppendLine($"{c.Name};{c.BandName};{c.Date:dd.MM.yyyy};{c.Payment:F2}");
            File.WriteAllText(_filePath, sb.ToString(), Encoding.UTF8);
            return $"CSV сохранён: {_filePath}";
        }
    }

    public class CsvContractsReport : IReport
    {
        private readonly List<Contract> _contracts;
        private readonly string _filePath;
        public string Title => "Отчёт по контрактам (CSV)";

        public CsvContractsReport(List<Contract> contracts, string filePath)
        {
            _contracts = contracts;
            _filePath = filePath;
        }

        public string Generate()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Продукт;Группа;Тип;Студия;Оплата;Дата начала;Дата конца");
            foreach (var c in _contracts)
                sb.AppendLine($"{c.ProductName};{c.BandName};{c.Type};{c.StudioName};{c.Payment:F2};{c.StartDate:dd.MM.yyyy};{c.EndDate:dd.MM.yyyy}");
            File.WriteAllText(_filePath, sb.ToString(), Encoding.UTF8);
            return $"CSV сохранён: {_filePath}";
        }
    }

    // ---- Конкретная фабрика — CSV формат ----

    public class CsvReportFactory : IReportFactory
    {
        private readonly string _outputFolder;

        public CsvReportFactory(string outputFolder)
        {
            _outputFolder = outputFolder;
            if (!Directory.Exists(_outputFolder))
                Directory.CreateDirectory(_outputFolder);
        }

        public IReport CreateMembersReport(List<Member> members) =>
            new CsvMembersReport(members,
                Path.Combine(_outputFolder, "members_report.csv"));

        public IReport CreateConcertsReport(List<Concert> concerts) =>
            new CsvConcertsReport(concerts,
                Path.Combine(_outputFolder, "concerts_report.csv"));

        public IReport CreateContractsReport(List<Contract> contracts) =>
            new CsvContractsReport(contracts,
                Path.Combine(_outputFolder, "contracts_report.csv"));
    }
}